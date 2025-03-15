using System.IdentityModel.Tokens.Jwt;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Application.Interfaces.IServices.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
}
