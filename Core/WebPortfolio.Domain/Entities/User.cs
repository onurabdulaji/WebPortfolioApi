using Microsoft.AspNetCore.Identity;

namespace WebPortfolioApi.Domain.Entities
{
    class User : IdentityUser<Guid>
    {
        public string? UserFullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public User() { }
    }
}
