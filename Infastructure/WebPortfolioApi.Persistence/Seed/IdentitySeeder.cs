using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Persistence.Seed;

public class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        const string adminRoleName = "Admin";
        const string adminEmail = "onurabdulaji@gmail.com";
        const string adminPassword = "Admin123!@#"; // Can be pulled from environment variable to be safe.


        //Is there an Admin Role? Or Add
        var roleExists = await roleManager.RoleExistsAsync(adminRoleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new Role { Name = adminRoleName });
        }

        // Is there an Admin User? If not, add
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                UserFullName = "Onur Abdulaji",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
            }
        }
    }
}
