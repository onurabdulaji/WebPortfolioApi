using Carter;
using System.IdentityModel.Tokens.Jwt;
using WebPortfolioApi.Application.Interfaces.IServices.Tokens;
using WebPortfolioApi.Application.ServiceManagers.Abstracts;

namespace WebPortfolioApi.WebApi.Endpoints
{
    public class LoginEndpoint : ICarterModule
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public LoginEndpoint(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/login", async (string email, string password) =>
            {
                var user = await _authenticationService.LogIn(email, password);
                var roles = await _authenticationService.GetLoginRoles(email, password);

                // JWT token oluşturma
                var token = await _tokenService.CreateToken(user, roles);

                // Token'i döndürüyoruz
                return Results.Ok(new
                {
                    userId = user.Id,
                    userFullName = user.UserFullName,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }).WithName("Login");
        }
    }
}
