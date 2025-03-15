using Microsoft.AspNetCore.Identity;
using WebPortfolioApi.Domain.Commons.Abstracts;
using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase
    {
        public string? UserFullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        // IEntityBase Özellikleri
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public User() { }
    }
}
