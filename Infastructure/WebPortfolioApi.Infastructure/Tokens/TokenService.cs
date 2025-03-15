﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebPortfolioApi.Application.Interfaces.Tokens;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Infastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly TokenSettings _tokenSettings;

    public TokenService(UserManager<User> userManager, TokenSettings tokenSettings)
    {
        _userManager = userManager;
        _tokenSettings = tokenSettings;
    }

    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

        var token = new JwtSecurityToken(
               issuer: _tokenSettings.Issuer,
               audience: _tokenSettings.Audience,
               expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMunitues),
               claims: claims,
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
               );

        await _userManager.AddClaimsAsync(user, claims);
        return token;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        TokenValidationParameters tokenValidationParamaters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret)),
            ValidateLifetime = false
        };
        JwtSecurityTokenHandler tokenHandler = new();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParamaters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg
            .Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Token bulunamadı.");

        return principal;
    }
}
