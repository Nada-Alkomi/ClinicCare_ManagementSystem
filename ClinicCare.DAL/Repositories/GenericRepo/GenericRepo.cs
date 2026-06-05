using System.Linq.Expressions;
using Clinic.Care.DAL.QueryHandler;
using ClinicCare.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Care.DAL.Repositories.GenericRepo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepo(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Query query,
        params Expression<Func<T, object>>[] include)
    {
        IQueryable<T> data = _dbSet.AsNoTracking();

        if (include != null && include.Length > 0)
        {
            foreach (var includeProperty in include)
            {
                data = data.Include(includeProperty);
            }
        }

        if (!string.IsNullOrEmpty(query.searchTarm))
        {
            data = data.Where(x =>
                EF.Property<string>(x, "Name")
                    .Contains(query.searchTarm));
        }

        var skip = (query.pageNumber - 1) * query.pagesize;

        return await data
            .Skip(skip)
            .Take(query.pagesize)
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();

        if (includes != null && includes.Any())
        {
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
        }

        return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }
}
