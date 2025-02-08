using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Handyman.Helper
{
    public static class IdentityInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await CreateRolesAndAdminUser(roleManager, userManager);
        }

        private static async Task CreateRolesAndAdminUser(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            string[] roles = { "Admin", "Customer", "Provider" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a default admin user
            var adminUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };

            string adminPassword = "Admin@123";
            if (await userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Define users
            var users = new List<IdentityUser>
            {
                new IdentityUser
                {
                    Id = "customer1",
                    UserName = "john.doe@example.com",
                    Email = "john.doe@example.com",
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "customer2",
                    UserName = "jane.smith@example.com",
                    Email = "jane.smith@example.com",
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "provider1",
                    UserName = "mike.johnson@example.com",
                    Email = "mike.johnson@example.com",
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "provider2",
                    UserName = "emily.davis@example.com",
                    Email = "emily.davis@example.com",
                    EmailConfirmed = true
                }
            };

            string defaultPassword = "Admin@123";
            // Create users and assign roles
            foreach (var u in users)
            {
                if (await userManager.FindByNameAsync(u.UserName) == null)
                {
                    var createUser = await userManager.CreateAsync(u, defaultPassword);
                    if (createUser.Succeeded)
                    {
                        if (u.Id.StartsWith("customer"))
                        {
                            await userManager.AddToRoleAsync(u, "Customer");
                        }
                        else if (u.Id.StartsWith("provider"))
                        {
                            await userManager.AddToRoleAsync(u, "Provider");
                        }
                    }
                    else
                    {
                        // Log errors if user creation fails
                        foreach (var error in createUser.Errors)
                        {
                            Console.WriteLine($"Error creating user {u.UserName}: {error.Description}");
                        }
                    }
                }
            }
        }
    }
}