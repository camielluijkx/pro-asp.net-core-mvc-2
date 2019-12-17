using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

            services.AddMvc();
        }

        private void mapRoutes1(IRouteBuilder routes)
        {
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}");
        }

        private void mapRoutes2(IRouteBuilder routes)
        {
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}",
                defaults: new { action = "Index" });
        }

        private void mapRoutes3(IRouteBuilder routes)
        {
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}");
        }

        private void mapRoutes4(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");
        }

        private void mapRoutes5(IRouteBuilder routes)
        {
            // http://localhost:52423/Public                                => Home/Index
            // http://localhost:52423/Public/Home                           => Home/Index
            // http://localhost:52423/Public/Home/Index                     => Home/Index
            // http://localhost:52423/Public/Admin                          => Admin/Index
            // http://localhost:52423/Public/Admin/Index                    => Admin/Index
            // http://localhost:52423/Public/Customer                       => Customer/Index
            // http://localhost:52423/Public/Customer/Index                 => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "public",
                template: "Public/{controller=Home}/{action=Index}");
        }

        private void mapRoutes6(IRouteBuilder routes)
        {
            // http://localhost:52423/XHome                                 => Home/Index
            // http://localhost:52423/XHome/Index                           => Home/Index
            // http://localhost:52423/XAdmin                                => Admin/Index
            // http://localhost:52423/XAdmin/Index                          => Admin/Index
            // http://localhost:52423/XCustomer                             => Customer/Index
            // http://localhost:52423/XCustomer/Index                       => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "cross",
                template: "X{controller=Home}/{action=Index}");

            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");

            // http://localhost:52423/Public                                => Home/Index
            // http://localhost:52423/Public/Home                           => Home/Index
            // http://localhost:52423/Public/Home/Index                     => Home/Index
            // http://localhost:52423/Public/Admin                          => Admin/Index
            // http://localhost:52423/Public/Admin/Index                    => Admin/Index
            // http://localhost:52423/Public/Customer                       => Customer/Index
            // http://localhost:52423/Public/Customer/Index                 => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "public",
                template: "Public/{controller=Home}/{action=Index}");
        }

        private void mapRoutes7(IRouteBuilder routes)
        {
            // http://localhost:52423/Shop/Index                            => Home/Index
            // else                                                         => next
            routes.MapRoute(
                name: "shopDefault",
                template: "Shop/{action}",
                defaults: new { controller = "Home" });

            // http://localhost:52423/XHome                                 => Home/Index
            // http://localhost:52423/XHome/Index                           => Home/Index
            // http://localhost:52423/XAdmin                                => Admin/Index
            // http://localhost:52423/XAdmin/Index                          => Admin/Index
            // http://localhost:52423/XCustomer                             => Customer/Index
            // http://localhost:52423/XCustomer/Index                       => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "cross",
                template: "X{controller=Home}/{action=Index}");

            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");

            // http://localhost:52423/Public                                => Home/Index
            // http://localhost:52423/Public/Home                           => Home/Index
            // http://localhost:52423/Public/Home/Index                     => Home/Index
            // http://localhost:52423/Public/Admin                          => Admin/Index
            // http://localhost:52423/Public/Admin/Index                    => Admin/Index
            // http://localhost:52423/Public/Customer                       => Customer/Index
            // http://localhost:52423/Public/Customer/Index                 => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "public",
                template: "Public/{controller=Home}/{action=Index}");
        }

        private void mapRoutes8(IRouteBuilder routes)
        {
            // http://localhost:52423/Shop/OldAction                        => Home/Index
            // else                                                         => next
            routes.MapRoute(
                name: "shopDefault",
                template: "Shop/OldAction",
                defaults: new { controller = "Home", action = "Index" });

            // http://localhost:52423/Shop/Index                            => Home/Index
            // else                                                         => next
            routes.MapRoute(
                name: "shopDefault",
                template: "Shop/{action}",
                defaults: new { controller = "Home" });

            // http://localhost:52423/XHome                                 => Home/Index
            // http://localhost:52423/XHome/Index                           => Home/Index
            // http://localhost:52423/XAdmin                                => Admin/Index
            // http://localhost:52423/XAdmin/Index                          => Admin/Index
            // http://localhost:52423/XCustomer                             => Customer/Index
            // http://localhost:52423/XCustomer/Index                       => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "cross",
                template: "X{controller=Home}/{action=Index}");

            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Admin                                 => Admin/Index
            // http://localhost:52423/Admin/Index                           => Admin/Index
            // http://localhost:52423/Customer                              => Customer/Index
            // http://localhost:52423/Customer/Index                        => Customer/Index
            // else                                                         => next
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");

            // http://localhost:52423/Public                                => Home/Index
            // http://localhost:52423/Public/Home                           => Home/Index
            // http://localhost:52423/Public/Home/Index                     => Home/Index
            // http://localhost:52423/Public/Admin                          => Admin/Index
            // http://localhost:52423/Public/Admin/Index                    => Admin/Index
            // http://localhost:52423/Public/Customer                       => Customer/Index
            // http://localhost:52423/Public/Customer/Index                 => Customer/Index
            // else                                                         => 404
            routes.MapRoute(
                name: "public",
                template: "Public/{controller=Home}/{action=Index}");
        }

        private void mapRoutes9(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Home/CustomVariable                   => Home/CustomVariable (DefaultId)
            // http://localhost:52423/Home/CustomVariable/Hello             => Home/CustomVariable (Hello)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id=DefaultId}");
        }

        private void mapRoutes10(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            // http://localhost:52423/Home/Index                            => Home/Index
            // http://localhost:52423/Home/CustomVariable                   => Home/CustomVariable (<no value>)
            // http://localhost:52423/Home/CustomVariable/Hello             => Home/CustomVariable (Hello)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"); // = UseMvcWithDefaultRoute
        }

        private void mapRoutes11(IRouteBuilder routes)
        {
            // http://localhost:52423/Customer/List                         => Customer/List
            // http://localhost:52423/Customer/List/Hellow/1/2/3            => Customer/List (CatchAll = 1/2/3)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
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
                //mapRoutes4(routes);
                //mapRoutes5(routes);
                //mapRoutes6(routes);
                //mapRoutes7(routes);
                //mapRoutes8(routes);
                //mapRoutes10(routes);
                mapRoutes11(routes);
            });

            //app.UseMvcWithDefaultRoute();
        }
    }
}