using LoggingApi.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog: logs to console and a rolling daily file
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Global exception handling registered first so it wraps everything downstream
app.UseGlobalExceptionHandling();

// Serilog's built-in request logging middleware (method, path, status, elapsed time)
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
