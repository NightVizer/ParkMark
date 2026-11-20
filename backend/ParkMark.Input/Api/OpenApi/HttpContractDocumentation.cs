using System.Globalization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using ParkMark.Input.Api.Contracts;

namespace ParkMark.Input.Api.OpenApi;

internal static class HttpContractDocumentation
{
    private const string BearerScheme = "Bearer";
    private const string JsonMediaType = "application/json";
    private const string ProblemMediaType = "application/problem+json";

    public static async Task AddDocumentMetadata(
        OpenApiDocument document,
        OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Info.Title = "ParkMark API";
        document.Info.Version = "v1";
        document.Info.Description =
            "HTTP-контракт ParkMark. Дата и время передаются в UTC. Вызовы заглушек возвращают 501.";

        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes[BearerScheme] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Description = "Передайте access-токен в заголовке Authorization."
        };

        var problemSchema = await context.GetOrCreateSchemaAsync(
            typeof(ApiProblem), cancellationToken: cancellationToken);
        document.AddComponent(nameof(ApiProblem), problemSchema);

        DescribeStringEnum(document, nameof(ConflictState));
        DescribeStringEnum(document, nameof(AdminActionKind));
    }

    public static Task AddOperationMetadata(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        var metadata = context.Description.ActionDescriptor.EndpointMetadata;
        var access = metadata.OfType<ApiAccessAttribute>().LastOrDefault()?.Level;
        var errors = metadata.OfType<ApiErrorsAttribute>()
            .GroupBy(error => error.StatusCode)
            .ToDictionary(
                group => group.Key,
                group => new HashSet<string>(group.SelectMany(error => error.Codes), StringComparer.Ordinal));

        if (operation.RequestBody is not null || operation.Parameters?.Count > 0)
        {
            AddError(errors, StatusCodes.Status400BadRequest, "validation_failed");
        }

        if (operation.RequestBody is OpenApiRequestBody { Content: { } content } requestBody &&
            content.TryGetValue(JsonMediaType, out var json))
        {
            requestBody.Content = new Dictionary<string, OpenApiMediaType> { [JsonMediaType] = json };
        }

        if (access != ApiAccessLevel.Anonymous)
        {
            operation.Security = [new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(BearerScheme, context.Document)] = []
            }];
            AddError(errors, StatusCodes.Status401Unauthorized, "unauthenticated");
        }

        if (access == ApiAccessLevel.Administrator)
        {
            operation.Description = string.IsNullOrWhiteSpace(operation.Description)
                ? "Требуется роль администратора."
                : $"{operation.Description}\n\nТребуется роль администратора.";
            AddError(errors, StatusCodes.Status403Forbidden, "forbidden");
        }

        AddError(errors, StatusCodes.Status500InternalServerError, "internal_error");
        var problemSchema = new OpenApiSchemaReference(nameof(ApiProblem), context.Document);

        operation.Responses ??= new OpenApiResponses();
        foreach (var (statusCode, codes) in errors)
        {
            var description = string.Join(", ", codes.Order(StringComparer.Ordinal).Select(code => $"`{code}`"));
            if (codes.Contains("no_spots"))
            {
                description += ". При `no_spots` передаётся `alternativeAddress`.";
            }

            operation.Responses[statusCode.ToString(CultureInfo.InvariantCulture)] =
                new OpenApiResponse
                {
                    Description = description,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        [ProblemMediaType] = new() { Schema = problemSchema }
                    }
                };
        }

        operation.Responses["501"] = new OpenApiResponse
        {
            Description = "Операция пока работает как заглушка."
        };

        return Task.CompletedTask;
    }

    private static void AddError(Dictionary<int, HashSet<string>> errors, int statusCode, string code)
    {
        if (!errors.TryGetValue(statusCode, out var codes))
        {
            codes = new HashSet<string>(StringComparer.Ordinal);
            errors.Add(statusCode, codes);
        }

        codes.Add(code);
    }

    private static void DescribeStringEnum(OpenApiDocument document, string name)
    {
        if (document.Components?.Schemas?.TryGetValue(name, out var component) == true &&
            component is OpenApiSchema { Enum: { } values } schema)
        {
            // Nullable enum properties carry their own null alternative to this component.
            schema.Type = JsonSchemaType.String;
            schema.Enum = values.Where(value => value is not null).ToList();
        }
    }
}
