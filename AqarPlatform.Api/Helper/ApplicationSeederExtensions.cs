using AqarPlatform.Domain.Entities;
using AqarPlatform.Persistence.Context;
using AqarPlatform.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AqarPlatform.Api.Helper;

public static class ApplicationSeederExtensions
{
    public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await context.Database.MigrateAsync();

        await AddDataSeeding.AddDataAsync(context, userManager,roleManager);

        return app;
    }
}