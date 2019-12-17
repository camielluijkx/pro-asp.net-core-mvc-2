using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfiguringApps
{
    public class Startup // Staging, Production
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) // Staging, Production
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc().AddMvcOptions(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) // Staging, Production
        {
            if ((Configuration.GetSection("ShortCircuitMiddleware")?
               .GetValue<bool>("EnableBrowserShortCircuit")).Value)
            {
                // ...
            }

            app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // http://localhost:51771                                   => /Home/Index
            // http://localhost:51771/Home                              => /Home/Index
            // http://localhost:51771/middleware                        => 404
            // http://localhost:51771/Home/Index                        => /Home/Index
            // http://localhost:51771/Home/Index?thowException=true     => /Home/Error
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
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
            // http://localhost:51771/middleware                        => middleware
            // http://localhost:51771/Home/Index                        => /Home/Index
            // http://localhost:51771/Home/Index?thowException=true     => exception
        }
    }
}