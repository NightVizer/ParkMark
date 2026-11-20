using System.Text.Json.Serialization;
using ParkMark.Input.Api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict)
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer(HttpContractDocumentation.AddDocumentMetadata);
    options.AddOperationTransformer(HttpContractDocumentation.AddOperationMetadata);
});

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "ParkMark API";
    options.SwaggerEndpoint("../openapi/v1.json", "ParkMark API v1");
});

app.MapControllers();
app.Run();

public partial class Program;
