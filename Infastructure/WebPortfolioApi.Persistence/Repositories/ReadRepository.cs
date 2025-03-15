using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebPortfolioApi.Application.Interfaces.Repositories;
using WebPortfolioApi.Domain.Commons.Abstracts;
using WebPortfolioApi.Persistence.Context;

namespace WebPortfolioApi.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> queryable = Table;

        if (predicate is not null) queryable = queryable.Where(predicate);

        return await queryable.AsNoTracking().CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        return queryable.Where(predicate);
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orderBy is not null)
            queryable = orderBy(queryable);

        return await queryable.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }
}
