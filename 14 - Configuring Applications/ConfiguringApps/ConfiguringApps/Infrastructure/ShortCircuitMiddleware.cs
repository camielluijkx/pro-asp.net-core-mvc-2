using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    /// <summary>
    /// Short-Circuiting Middleware
    /// </summary>
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ShortCircuitMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _requestDelegate.Invoke(httpContext);
            }
        }
    }
}