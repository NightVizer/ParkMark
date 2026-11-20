using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ParkMark.Input.Tests;

public sealed class SwaggerContractTests(WebApplicationFactory<Program> application)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task SwaggerUiAndOpenApiAreAvailable()
    {
        using var client = application.CreateClient();
        var html = await client.GetStringAsync("/swagger/index.html");
        Assert.Contains("ParkMark API", html);

        using var document = await GetOpenApiAsync(client);
        var paths = document.RootElement.GetProperty("paths");
        var operationCount = paths.EnumerateObject().Sum(path => path.Value.EnumerateObject().Count());
        Assert.Equal(40, operationCount);
    }

    [Fact]
    public async Task BookingDeadlineMayBeOmittedOrNull()
    {
        using var client = application.CreateClient();
        using var document = await GetOpenApiAsync(client);
        var schema = document.RootElement.GetProperty("components").GetProperty("schemas")
            .GetProperty("BookingResponse");

        Assert.DoesNotContain(schema.GetProperty("required").EnumerateArray(),
            field => field.GetString() == "deadlineAt");
        var deadline = schema.GetProperty("properties").GetProperty("deadlineAt");
        Assert.Contains(deadline.GetProperty("type").EnumerateArray(), type => type.GetString() == "null");
        Assert.Equal("date-time", deadline.GetProperty("format").GetString());
    }

    [Fact]
    public async Task IdentificationIsPublicAndItsStubReturnsNotImplemented()
    {
        using var client = application.CreateClient();
        using var document = await GetOpenApiAsync(client);
        var operation = document.RootElement.GetProperty("paths")
            .GetProperty("/api/v1/auth/identify").GetProperty("post");

        Assert.False(operation.TryGetProperty("security", out _));
        var body = operation.GetProperty("requestBody");
        Assert.True(body.GetProperty("required").GetBoolean());
        Assert.Equal("application/json", Assert.Single(body.GetProperty("content").EnumerateObject()).Name);
        Assert.False(operation.GetProperty("responses").GetProperty("204").TryGetProperty("content", out _));

        using var response = await client.PostAsJsonAsync("/api/v1/auth/identify", new { employeeId = "123" });
        Assert.Equal(HttpStatusCode.NotImplemented, response.StatusCode);
    }

    [Fact]
    public async Task BookingConflictsExposeEveryReasonAndTheSameProblemSchema()
    {
        using var client = application.CreateClient();
        using var document = await GetOpenApiAsync(client);
        var operation = document.RootElement.GetProperty("paths")
            .GetProperty("/api/v1/bookings").GetProperty("post");

        Assert.True(operation.GetProperty("security")[0].TryGetProperty("Bearer", out _));
        var conflict = operation.GetProperty("responses").GetProperty("409");
        var description = conflict.GetProperty("description").GetString();
        Assert.Contains("no_spots", description);
        Assert.Contains("booking_already_active", description);
        Assert.Contains("already_occupying", description);
        Assert.Contains("alternativeAddress", description);
        var schema = conflict.GetProperty("content").GetProperty("application/problem+json").GetProperty("schema");
        Assert.Equal("#/components/schemas/ApiProblem", schema.GetProperty("$ref").GetString());
    }

    [Theory]
    [InlineData("/api/v1/auth/refresh", "post")]
    [InlineData("/api/v1/me/password", "put")]
    public async Task TokenRotationDocumentsTheNewTokenPair(string path, string method)
    {
        using var client = application.CreateClient();
        using var document = await GetOpenApiAsync(client);
        var schema = document.RootElement.GetProperty("paths").GetProperty(path).GetProperty(method)
            .GetProperty("responses").GetProperty("200").GetProperty("content")
            .GetProperty("application/json").GetProperty("schema");

        Assert.Equal("#/components/schemas/TokenPairResponse", schema.GetProperty("$ref").GetString());
    }

    [Fact]
    public async Task AdminConflictFilterUsesTheDocumentedStringsAndRequiresAdministratorRole()
    {
        using var client = application.CreateClient();
        using var document = await GetOpenApiAsync(client);
        var operation = document.RootElement.GetProperty("paths")
            .GetProperty("/api/v1/admin/conflicts").GetProperty("get");

        Assert.True(operation.GetProperty("security")[0].TryGetProperty("Bearer", out _));
        Assert.Contains("Требуется роль администратора", operation.GetProperty("description").GetString());
        var state = Assert.Single(operation.GetProperty("parameters").EnumerateArray(),
            parameter => parameter.GetProperty("name").GetString() == "state");
        Assert.Equal("query", state.GetProperty("in").GetString());

        var schema = document.RootElement.GetProperty("components").GetProperty("schemas").GetProperty("ConflictState");
        Assert.Equal("string", schema.GetProperty("type").GetString());
        Assert.Equal(["open", "resolved"], schema.GetProperty("enum").EnumerateArray().Select(value => value.GetString()));
    }

    private static async Task<JsonDocument> GetOpenApiAsync(HttpClient client) =>
        JsonDocument.Parse(await client.GetStringAsync("/openapi/v1.json"));
}
