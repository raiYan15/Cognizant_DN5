namespace FilterDemoApi.Middleware
{
    // Custom middleware that logs every incoming request and its response time.
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            _logger.LogInformation("Incoming {Method} {Path}", context.Request.Method, context.Request.Path);

            await _next(context); // pass control to the next middleware in the pipeline

            var elapsedMs = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation(
                "Completed {Method} {Path} -> {StatusCode} in {Elapsed}ms",
                context.Request.Method, context.Request.Path, context.Response.StatusCode, elapsedMs);
        }
    }

    // Extension method for clean registration in Program.cs
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
