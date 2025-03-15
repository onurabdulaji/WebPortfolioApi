using Microsoft.EntityFrameworkCore;
using WebPortfolioApi.Application.Interfaces.Repositories;
using WebPortfolioApi.Domain.Commons.Abstracts;
using WebPortfolioApi.Persistence.Context;

namespace WebPortfolioApi.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }
    private DbSet<T> Table { get => _context.Set<T>(); }
    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(T entity)
    {
        Table.Remove(entity); 
        await _context.SaveChangesAsync(); 
        return entity;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        Table.Update(entity); 
        await _context.SaveChangesAsync();
        return entity;
    }
}
