using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Views.Infrastructure;

namespace Views
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.Configure<MvcViewOptions>(options => {
            //    options.ViewEngines.Clear();
            //    options.ViewEngines.Insert(0, new DebugDataViewEngine());
            //});
            services.Configure<RazorViewEngineOptions>(options =>
            {
                // http://localhost:53742/Home/Index
                // /Views/Home/MyView.cshtml
                // /Views/Shared/MyView.cshtml
                // /Views/Legacy/Home/MyView/View.cshtml
                options.ViewLocationExpanders.Add(new SimpleExpander());

                // http://localhost:53742/Home/Index/Red
                // /Views/Home/Red.cshtml
                // /Views/Common/Red.cshtml
                // /Views/Legacy/Home/Red/View.cshtml
                // http://localhost:53742/Home/Index/Green
                // /Views/Home/Green.cshtml
                // /Views/Common/Green.cshtml
                // /Views/Legacy/Home/Green/View.cshtml
                // http://localhost:53742/Home/Index/Blue
                // /Views/Home/Blue.cshtml
                // /Views/Common/Blue.cshtml
                // /Views/Legacy/Home/Blue/View.cshtml
                options.ViewLocationExpanders.Add(new ColorExpander());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}