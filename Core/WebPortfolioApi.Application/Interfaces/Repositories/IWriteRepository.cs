using WebPortfolioApi.Domain.Commons.Abstracts;

namespace WebPortfolioApi.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class,IEntityBase,new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

}
