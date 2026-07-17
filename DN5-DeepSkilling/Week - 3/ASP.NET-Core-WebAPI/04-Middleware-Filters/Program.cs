using FilterDemoApi.Filters;
using FilterDemoApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // Register exception filter globally so it applies to every controller/action
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddScoped<CustomActionFilter>(); // used via [ServiceFilter] on controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Custom middleware registered early in the pipeline to log every request
app.UseRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
