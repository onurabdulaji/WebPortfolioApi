using WebPortfolioApi.Domain.Commons.Abstracts;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Application.Interfaces.IRepositories.Authentication;

public interface IReadAuthenticationRepository : IReadRepository<User>
{
}
