using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger/OpenAPI configuration with rich metadata + XML comments
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Web API Demo",
        Version = "v1",
        Description = "Demonstrates Swagger/OpenAPI integration in ASP.NET Core 8 Web API",
        Contact = new OpenApiContact
        {
            Name = "Kakumanu Venkata Sadwik",
            Email = "sample@example.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Swagger middleware - exposes /swagger and the JSON spec at /swagger/v1/swagger.json
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Web API Demo v1");
    options.RoutePrefix = string.Empty; // Swagger UI served at root "/"
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
