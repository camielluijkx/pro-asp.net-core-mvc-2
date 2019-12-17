using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return new WebHostBuilder()

                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config
                        .AddJsonFile("appsettings.json",
                            optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                            optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })

                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(
                        hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                
                .UseIISIntegration()
                
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes =
                        context.HostingEnvironment.IsDevelopment();
                })
                
                //.UseStartup<Startup>()
                .UseStartup(nameof(ConfiguringApps))
                
                .Build();
        }
    }
}