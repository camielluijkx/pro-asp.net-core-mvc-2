using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public class Startup
    {
        private IHostingEnvironment env;

        public Startup(IHostingEnvironment hostEnv) => env = hostEnv;

        public void ConfigureServices(IServiceCollection services)
        {
            //TypeBroker.SetRepositoryType<AlternateRepository>();

            //services.AddTransient<IRepository, MemoryRepository>();
            //services.AddTransient<IModelStorage, DictionaryStorage>();
            //services.AddTransient<ProductTotalizer>();

            //services.AddTransient<IRepository>(provider =>
            //{
            //    if (env.IsDevelopment())
            //    {
            //        MemoryRepository repo = provider.GetService<MemoryRepository>();

            //        return repo;
            //    }
            //    else
            //    {
            //        return new AlternateRepository();
            //    }
            //});
            //services.AddTransient<MemoryRepository>();
            //services.AddTransient<IModelStorage, DictionaryStorage>();
            //services.AddTransient<ProductTotalizer>();

            //services.AddScoped<IRepository, MemoryRepository>();
            //services.AddTransient<IModelStorage, DictionaryStorage>();
            //services.AddTransient<ProductTotalizer>();

            services.AddSingleton<IRepository, MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();

            services.AddMvc();
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