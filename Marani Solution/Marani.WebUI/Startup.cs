using Marani.Domain.AppCode.Extensions;
using Marani.Domain.AppCode.Services;
using Marani.Domain.Models.DataContexts;
using Marani.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Marani.WebUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;   // json file larini oxuya bilmek uchun
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<MaraniDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });



            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            })
             .AddIdentity<MaraniUser, MaraniRole>()
            .AddEntityFrameworkStores<MaraniDbContext>()
            .AddDefaultTokenProviders();

            services.AddSingleton<EmailService>();
            services.AddSingleton<CryptoService>();


            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.AddScoped<IClaimsTransformation, AppClaimProvider>();


            services.AddScoped<UserManager<MaraniUser>>();
            services.AddScoped<SignInManager<MaraniUser>>();

            services.Configure<IdentityOptions>(cfg => {
                cfg.User.RequireUniqueEmail = true; //herkesin bir emaili olsun
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredUniqueChars = 1; //123
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 1, 0);
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Password.RequiredLength = 3;

            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accesdenied.html";

                cfg.Cookie.Name = "Marani";
                cfg.Cookie.HttpOnly = true;
                cfg.ExpireTimeSpan = new TimeSpan(4, 15, 0);
            });



            services.AddAuthentication();
            services.AddAuthorization(cfg =>
            {

                foreach (var policyName in Extension.policies)
                {
                    cfg.AddPolicy(policyName, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("SuperAdmin") ||
                            handler.User.HasClaim(policyName, "1");
                        });
                    });

                }
            });

            services.AddScoped<UserManager<MaraniUser>>();
            services.AddScoped<SignInManager<MaraniUser>>();
            services.AddScoped<RoleManager<MaraniRole>>();

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddRouting(cfg =>    // url lerin kichik herfle gorunmesi uchun
            {
                cfg.LowercaseUrls = true;
            });


            var asemblies = AppDomain.CurrentDomain.GetAssemblies().AsEnumerable().Where(a => a.FullName.StartsWith("Marani."));

            services.AddMediatR(asemblies.ToArray());
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<MaraniRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.SeedMembership();
            app.SeedData();

            //MaraniDbSeed.SeedUserRole(roleManager);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

          

            app.UseEndpoints(cfg =>
            {
				cfg.MapAreaControllerRoute("defaultAdmin", "admin", "admin/{controller=dashboard}/{action=index}/{id?}");

				cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
