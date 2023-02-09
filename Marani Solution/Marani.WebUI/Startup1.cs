using Marani.Domain.AppCode.Extensions;
using Marani.Domain.AppCode.Services;
using Marani.Domain.Models.DataContexts;
using Marani.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Marani.WebUI
{
    public class Startup1
    {
        private readonly IConfiguration configuration;

        public Startup1(IConfiguration configuration)
        {
            this.configuration = configuration;
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

                //cfg.UseSqlServer(configuration.GetConnectionString("cString"));
                cfg.UseSqlServer(configuration["ConnectionStrings:cString"]);
            });


            services.SetupIdentity();

            services.AddAuthentication();

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("admin.brands.index", p =>
                {
                    p.RequireClaim("admin.brands.index", "1");
                });

                cfg.AddPolicy("admin.brands.details", p =>
                {
                    p.RequireClaim("admin.brands.details", "1");
                });

                cfg.AddPolicy("admin.brands.create", p =>
                {
                    p.RequireClaim("admin.brands.create", "1");
                });

                cfg.AddPolicy("admin.brands.edit", p =>
                {
                    p.RequireClaim("admin.brands.edit", "1");
                });

                cfg.AddPolicy("admin.brands.remove", p =>
                {
                    p.RequireClaim("admin.brands.remove", "1");
                });


            });
            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptography").Bind(cfg); 

            });

            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);

            });

            services.AddSingleton<CryptoService>();

            //var relatedAssembly = Assembly.LoadFrom("bin/Debug/net5.0/Marani.Domain.dll");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().AsEnumerable().Where(a => a.FullName.StartsWith("Marani."));

            services.AddMediatR(assemblies.ToArray());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SeedData();
            app.SeedMembership();

            app.UseStaticFiles();
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
