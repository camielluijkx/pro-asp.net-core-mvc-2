using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    /// <summary>
    /// Request-Editing Middleware
    /// </summary>
    public class BrowserTypeMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public BrowserTypeMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"]
                = httpContext.Request.Headers["User-Agent"]
                    .Any(v => v.ToLower().Contains("edge"));

            await _requestDelegate.Invoke(httpContext);
        }
    }
}