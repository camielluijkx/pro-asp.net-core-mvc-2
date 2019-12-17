using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ConfiguringApps
{
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ErrorMiddleware>();
            app.UseMiddleware<BrowserTypeMiddleware>();
            app.UseMiddleware<ShortCircuitMiddleware>();
            app.UseMiddleware<ContentMiddleware>();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseBrowserLink();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            // http://localhost:51771                                   => /Home/Index
            // http://localhost:51771/Home                              => /Home/Index
            // http://localhost:51771/middleware                        => 404
            // http://localhost:51771/Home/Index                        => /Home/Index
            // http://localhost:51771/Home/Index?thowException=true     => /Home/Error
        }
    }
}