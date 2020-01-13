using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
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
            // http://localhost:52423/Customer/List/Hello/1/2/3             => Customer/List (CatchAll = 1/2/3)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
        }

        private void mapRoutes12(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home/CustomVariable/Hello             => 404
            // http://localhost:52423/Home/CustomVariable/1                 => Home/Index (Id = 1)
            // http://localhost:52423/Home/CustomVariable/1/2               => 404
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id:int?}");
        }

        private void mapRoutes13(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home/CustomVariable/Hello             => 404
            // http://localhost:52423/Home/CustomVariable/1                 => Home/Index (Id = 1)
            // http://localhost:52423/Home/CustomVariable/1/2               => 404
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = new IntRouteConstraint() });
        }

        private void mapRoutes14(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            routes.MapRoute(
                name: "default",
                template: "{controller:regex(^H.*)=Home}/{action=Index}/{id?}"); // will only match URL's where controller segment starts with H
        }

        private void mapRoutes15(IRouteBuilder routes)
        {
            // http://localhost:52423                                       => Home/Index
            // http://localhost:52423/Home                                  => Home/Index
            routes.MapRoute(
                name: "default",
                template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}"); // will only match URL's where controller segment starts with H and action is Index or About
        }

        private void mapRoutes16(IRouteBuilder routes)
        {
            // http://localhost:52423/Home/Index/9                          => 404
            // http://localhost:52423/Home/Index/10                         => Home/Index (Id = 10)
            // ...
            // http://localhost:52423/Home/Index/20                         => Home/Index (Id = 20)
            // http://localhost:52423/Home/Index/21                         => 404
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");
        }

        private void mapRoutes17(IRouteBuilder routes)
        {
            // http://localhost:52423/Home/Index/1                          => 404
            // http://localhost:52423/Home/Index/1abcde                     => 404
            // http://localhost:52423/Home/Index/abcdef                     => Home/Index (Id = abcdef)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
        }

        private void mapRoutes18(IRouteBuilder routes)
        {
            // http://localhost:52423/Home/Index/1                          => 404
            // http://localhost:52423/Home/Index/1abcde                     => 404
            // http://localhost:52423/Home/Index/abcdef                     => Home/Index (Id = abcdef)
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = new CompositeRouteConstraint(
                    new IRouteConstraint[] 
                    {
                        new AlphaRouteConstraint(),
                        new MinLengthRouteConstraint(6)
                    })
                });
        }

        private void mapRoutes19(IRouteBuilder routes)
        {
            // http://localhost:52423/Customer/List                         => 404
            // http://localhost:52423/Customer/List/Abc                     => 404
            // http://localhost:52423/Customer/List/Fri                     => Customer/List (Id = Fri)
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = new WeekDayConstraint() });
        }

        private void mapRoutes20(IRouteBuilder routes)
        {
            // http://localhost:52423/Customer/List                         => 404
            // http://localhost:52423/Customer/List/Abc                     => 404
            // http://localhost:52423/Customer/List/Fri                     => Customer/List (Id = Fri)
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id:weekday?}");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
                //mapRoutes1(routes);
                //mapRoutes2(routes);
                //mapRoutes3(routes);
                //mapRoutes4(routes);
                //mapRoutes5(routes);
                //mapRoutes6(routes);
                //mapRoutes7(routes);
                //mapRoutes8(routes);
                //mapRoutes10(routes);
                //mapRoutes11(routes);
                //mapRoutes12(routes);
                //mapRoutes13(routes);
                //mapRoutes14(routes);
                //mapRoutes15(routes);
                //mapRoutes16(routes);
                //mapRoutes17(routes);
                //mapRoutes18(routes);
                //mapRoutes19(routes);
                //mapRoutes20(routes);
            //});

            app.UseMvcWithDefaultRoute();
        }
    }
}