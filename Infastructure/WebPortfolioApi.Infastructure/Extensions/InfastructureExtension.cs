using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPortfolioApi.Application.Interfaces.IServices.Tokens;
using WebPortfolioApi.Infrastructure.Services.Tokens;

namespace WebPortfolioApi.Infastructure.Extensions
{
    public static class InfastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITokenService, TokenService>();

        }
    }
}
