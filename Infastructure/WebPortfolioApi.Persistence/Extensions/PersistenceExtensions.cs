using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPortfolioApi.Application.Interfaces.IRepositories;
using WebPortfolioApi.Application.Interfaces.UnitOfWorks;
using WebPortfolioApi.Application.ServiceManagers.Abstracts;
using WebPortfolioApi.Application.ServiceManagers.Concretes;
using WebPortfolioApi.Domain.Entities;
using WebPortfolioApi.Persistence.Context;
using WebPortfolioApi.Persistence.Repositories;
using WebPortfolioApi.Persistence.Seed;
using WebPortfolioApi.Persistence.UnitOfWorks;

namespace WebPortfolioApi.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthenticationService, AuthenticationManager>();

        services.AddIdentity<User, Role>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 2;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = false;
        })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
    public static async Task UseIdentityDatabaseSeederAsync(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            await IdentitySeeder.SeedAsync(userManager, roleManager);
        }
    }
}
