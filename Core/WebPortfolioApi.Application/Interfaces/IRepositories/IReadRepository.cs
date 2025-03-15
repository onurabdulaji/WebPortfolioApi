using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebPortfolioApi.Domain.Commons.Abstracts;

namespace WebPortfolioApi.Application.Interfaces.IRepositories;

public interface IReadRepository<T> where T : class,new()
{
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
    IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    Task<T> FindAsync(Expression<Func<T, bool>> predicate);
}

