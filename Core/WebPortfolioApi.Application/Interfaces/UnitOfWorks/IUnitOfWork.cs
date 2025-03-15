using WebPortfolioApi.Application.Interfaces.Repositories;
using WebPortfolioApi.Domain.Commons.Abstracts;

namespace WebPortfolioApi.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync();
    int Save();
}
