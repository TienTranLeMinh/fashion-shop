using FashionShop.Core.Interface;
using FashionShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FashionShop.Infrastructure.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T Entity)
    {
        await _context.Set<T>().AddAsync(Entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] includes)
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var query = _context.Set<T>().AsQueryable().AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var item in includes)
        {
            query = query.Include(item);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return await ((DbSet<T>)query).FindAsync(id);
    }

    public async Task UpdateAsync(int id, T Entity)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity is not null)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
