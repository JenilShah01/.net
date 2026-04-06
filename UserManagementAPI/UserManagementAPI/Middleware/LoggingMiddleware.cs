using System.Diagnostics;

namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine(
                $"{context.Request.Method} {context.Request.Path} " +
                $"Status: {context.Response.StatusCode} " +
                $"Time: {stopwatch.ElapsedMilliseconds}ms"
            );
        }
    }
}