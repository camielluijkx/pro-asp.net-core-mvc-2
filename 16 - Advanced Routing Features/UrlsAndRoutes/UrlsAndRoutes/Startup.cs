using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));

                // Home/CustomVariable => home/customvariable/
                options.LowercaseUrls = false;
                options.AppendTrailingSlash = false;
            });
            services.AddMvc();
        }

        private void mapRoutes1(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }

        private void mapRoutes2(IRouteBuilder routes)
        {
            //routes.MapRoute(
            //    name: "NewRoute",
            //    template: "App/Do{action}",
            //    defaults: new { controller = "Home" });

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "out",
                template: "outbound/{controller=Home}/{action=Index}");
        }

        private void mapRoutes3(IRouteBuilder routes)
        {
            routes.Routes.Add(new LegacyRoute(
                "/articles/Windows_3.1_Overview.html",
                "/old/.NET_1.0_Class_Library"));

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "out",
                template: "outbound/{controller=Home}/{action=Index}");
        }

        private void mapRoutes4(IApplicationBuilder app, IRouteBuilder routes)
        {
            routes.Routes.Add(new LegacyRoute(
                app.ApplicationServices,
                "/articles/Windows_3.1_Overview.html",
                "/old/.NET_1.0_Class_Library"));

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "out",
                template: "outbound/{controller=Home}/{action=Index}");
        }

        private void mapRoutes5(IApplicationBuilder app, IRouteBuilder routes)
        {
            // area: exists => ensures requests are matched only to areas that have been defined 
            routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}");

            routes.Routes.Add(new LegacyRoute(
                app.ApplicationServices,
                "/articles/Windows_3.1_Overview.html",
                "/old/.NET_1.0_Class_Library"));

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "out",
                template: "outbound/{controller=Home}/{action=Index}");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //mapRoutes1(routes);
                //mapRoutes2(routes);
                //mapRoutes3(routes);
                //mapRoutes4(app, routes);
                mapRoutes5(app, routes);
            });
        }
    }
}