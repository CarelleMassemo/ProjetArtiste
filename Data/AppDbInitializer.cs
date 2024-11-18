using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetArtiste1.Data.Enum;
using ProjetArtiste1.Data.Static;
using ProjetArtiste1.Models;
using System;
using System.Xml.Linq;

namespace ProjetArtiste1.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // oeuvre
                if (!context.Oeuvres.Any())
                {
                    context.Oeuvres.AddRange(new List<Oeuvre>()
                {
                        new Oeuvre()
                            {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.peinture
                        },
                        new Oeuvre()
                        {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.Sculture
                        },
                        new Oeuvre()
                        {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.HomeDeco
                        },
                        new Oeuvre()
                        {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.Masque
                        },
                        new Oeuvre()
                        {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.Sculture
                        },
                        new Oeuvre()
                        {
                            nom = "Life",
                            description = "This is the Life movie description",
                            prix = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            dateCreation = DateTime.Now.AddDays(-10),
                            oeuvreCategorie = OeuvreCategorie.HomeDeco
                        }
                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@artiste.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@artiste.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

