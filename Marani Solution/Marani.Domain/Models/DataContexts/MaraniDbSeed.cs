using Marani.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Marani.Domain.Models.DataContexts
{
    public static class MaraniDbSeed
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MaraniDbContext>();

                db.Database.Migrate(); //update-database automatically


                InitBrands(db);
            }

            return app;
        }


        public static IApplicationBuilder SeedMembership(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<MaraniUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<MaraniRole>>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                string superAdminRoleName = configuration["defaultAccount:superAdmin"];
                string superAdminEmail = configuration["defaultAccount:email"];
                string superAdminUserName = configuration["defaultAccount:username"];
                string superAdminPassword = configuration["defaultAccount:password"];

                var superAdminRole = roleManager.FindByNameAsync(superAdminRoleName).Result;

                if (superAdminRole == null)
                {
                    superAdminRole = new MaraniRole
                    {
                        Name = superAdminRoleName
                    };

                    var roleResult = roleManager.CreateAsync(superAdminRole).Result;

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("RoleCreating Error");
                    }
                }



                var superAdminUser = userManager.FindByEmailAsync(superAdminEmail).Result;
                if (superAdminUser == null)
                {
                    superAdminUser = new MaraniUser
                    {
                        Email = superAdminEmail,
                        UserName = superAdminUserName
                    };
                    var userrResult = userManager.CreateAsync(superAdminUser, superAdminPassword).Result;
                    if (userrResult.Succeeded)
                    {
                        throw new Exception("UserCreating Error");

                    }
                }

                var isInRole = userManager.IsInRoleAsync(superAdminUser, superAdminRole.Name).Result;
                if (isInRole != true)
                {
                    userManager.AddToRoleAsync(superAdminUser, superAdminRole.Name).Wait();
                }
            }

            return app;
        }

        private static void InitBrands(MaraniDbContext db)
        {
            if (!db.Brands.Any())
            {
                db.Brands.Add(new Entities.Brand()
                {
                    Name = "Chacha"

                });

                db.Brands.Add(new Entities.Brand()
                {
                    Name = "Whiskey"

                });

                db.SaveChanges();
            }
        }

    }
}
