using Microsoft.AspNetCore.Identity;
using WebPortfolioApi.Domain.Commons.Abstracts;
using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? UserFullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public User() { }
    }
}
