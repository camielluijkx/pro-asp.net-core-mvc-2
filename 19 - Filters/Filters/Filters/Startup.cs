using Filters.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Filters
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics

            //services.AddSingleton<IFilterDiagnostics, DefaultFilterDiagnostics>();
            //services.AddSingleton<TimeFilter>();

            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();

            //services.AddMvc();

            //services.AddMvc().AddMvcOptions(options =>
            //{
            //    options.Filters.AddService(typeof(ViewResultDiagnostics));
            //    options.Filters.AddService(typeof(DiagnosticsFilter));
            //});

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add(new
                    MessageAttribute("This is the Globally-Scoped Filter"));
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