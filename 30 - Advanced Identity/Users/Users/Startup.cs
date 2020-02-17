﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Users.Infrastructure;
using Users.Models;

namespace Users
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddSingleton<IClaimsTransformation, LocationClaimsProvider>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();

            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("DCUsers", policy =>
                {
                    policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                });

                opts.AddPolicy("NotBob", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement("Bob"));
                });

                opts.AddPolicy("AuthorsAndEditors", policy =>
                {
                    policy.AddRequirements(new DocumentAuthorizationRequirement
                    {
                        AllowAuthors = true,
                        AllowEditors = true
                    });
                });
            });

            services.AddAuthentication().AddGoogle(opts =>
            {
                opts.ClientId = "<enter client id here>";
                opts.ClientSecret = "<enter client secret here>";
            });

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportStoreIdentity:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();

            /*
                       
            http://localhost:62542 + NotAuthenticated => http://localhost:62542/Account/Login?ReturnUrl=%2F
            http://localhost:62542 + Authenticated > Logout => http://localhost:62542
            http://localhost:62542 + Authenticated => http://localhost:62542
            http://localhost:62542/Admin => manage users
            http://localhost:62542/RoleAdmin => manage roles
            http://localhost:62542/Home/UserProps => view user props
            http://localhost:62542/Claims => view claims
            http://localhost:62542/Home/OtherAction => accessible by DCUsers
            http://localhost:62542/Home/NotBob => not accessible by Bob
            http://localhost:62542/Document/Edit?title=Project%20Plan => editable by author or editor

            */
            app.UseMvcWithDefaultRoute();
        }
    }
}