using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using ThAmCo_Commerce.Data.Static;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "White T",
                            ProductPrice = 9.99,
                            ProductStock = 5,
                            ProductPictureUrl = "https://cdn.pixabay.com/photo/2017/01/13/04/56/t-shirt-1976334__480.png"
                        },

                    });
                    context.SaveChanges();
                }


            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService< Microsoft.AspNetCore.Identity.RoleManager < IdentityRole >> ();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<AppUser>>();
                string adminEmail = "admin@test.com";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "TestAdmin");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string userEmail = "user@test.com";

                var appUser = await userManager.FindByEmailAsync(userEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "App User",
                        UserName = "app-user",
                        Email = userEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "TestUser");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);



                }
            }
        }
    }
}

