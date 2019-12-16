using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    /// <summary>
    /// Content-Generating Middleware
    /// </summary>
    public class ContentMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly UptimeService _uptimeService;

        public ContentMiddleware(RequestDelegate requestDelegate, UptimeService uptimeService)
        {
            _requestDelegate = requestDelegate;
            _uptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                    $"This is from the content middleware (uptime: {_uptimeService.Uptime}ms)"
                    , Encoding.UTF8);
            }
            else
            {
                await _requestDelegate.Invoke(httpContext);
            }
        }
    }
}