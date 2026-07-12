using AqarPlatform.Domain.Entities;
using AqarPlatform.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AqarPlatform.Persistence.Seed
{
    public static class AddDataSeeding
    {
        public static async Task AddDataAsync(ApplicationDbContext dbContext,UserManager<ApplicationUser > userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            // user 
            if (!dbContext.Users.Any())
            {
                var filePath = Path.Combine(
                    AppContext.BaseDirectory, "Seed", "Data","user.json");

                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);

                    var users = JsonSerializer.Deserialize<List<ApplicationUser>>(json);

                    if (users is not null && users.Any())
                    {
                        foreach (var user in users)
                        {
                            var result = await userManager.CreateAsync(user, "P@ssword123");

                            if (!result.Succeeded)
                            {
                                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
                            }
                        }
                    }

                    return;
                }
            }

            // Role
            if (!dbContext.Roles.Any())
            {
                var filePath = Path.Combine(
                    AppContext.BaseDirectory, "Seed", "Data", "roles.json");

                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);

                    var roles = JsonSerializer.Deserialize<List<IdentityRole<Guid>>>(json);

                    if (roles is not null)
                    {
                        foreach (var role in roles)
                        {
                            var result = await roleManager.CreateAsync(role);

                            if (!result.Succeeded)
                            {
                                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
                            }
                        }
                    }

                    return;
                }
            }

        }
    }
}
