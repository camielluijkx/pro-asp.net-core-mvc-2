using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        private string[] urls;
        private IRouter mvcRoute;

        public LegacyRoute(params string[] targetUrls)
        {
            this.urls = targetUrls;
        }

        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            this.urls = targetUrls;
            mvcRoute = services.GetRequiredService<MvcRouteHandler>();
        }

        private Task routeAsync1(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path
               .Value.TrimEnd('/');

            if (urls.Contains(requestedUrl))
            {
                context.Handler = async ctx => 
                {
                    HttpResponse response = ctx.Response;

                    byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");

                    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                };
            }

            return Task.CompletedTask;
        }

        private async Task routeAsync2(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path
               .Value.TrimEnd('/');

            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;

                await mvcRoute.RouteAsync(context);
            }
        }

        public async Task RouteAsync(RouteContext context)
        {
            //await routeAsync1(context);
            await routeAsync2(context);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;

                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }

            return null;
        }
    }
}