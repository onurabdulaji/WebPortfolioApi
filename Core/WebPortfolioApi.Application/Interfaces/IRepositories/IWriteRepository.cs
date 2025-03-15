using WebPortfolioApi.Domain.Commons.Abstracts;

namespace WebPortfolioApi.Application.Interfaces.IRepositories;

public interface IWriteRepository<T> where T : class,new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

}
