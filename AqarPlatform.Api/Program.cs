using AqarPlatform.Api.ExMethod;
using AqarPlatform.Api.Helper;
using AqarPlatform.Application.Interfaces;
using AqarPlatform.Application.Mapping;
using AqarPlatform.Application.Services;
using AqarPlatform.Domain.Entities;
using AqarPlatform.Domain.Interfaces;
using AqarPlatform.Infrastructure.Jwt;
using AqarPlatform.Persistence.Context;
using AqarPlatform.Persistence.Repositories;
using AqarPlatform.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddSwaggerService();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(a => a.AddProfile(new MappingProfile()));



var app = builder.Build();
await app.SeedDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
