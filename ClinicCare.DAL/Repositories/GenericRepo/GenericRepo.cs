using System.Linq.Expressions;
using Clinic.Care.DAL.QueryHandler;
using ClinicCare.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Care.DAL.Repositories.GenericRepo;

public class GenericRepo<T>:IGenericRepo<T> where T:class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepo(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    
    public Task<IEnumerable<T>> GetAllAsync(Query query, Expression<Func<T, object>>? include)
    {
        IQueryable<T> queryable = _dbSet;
        if (include != null)
        {
            queryable = queryable.Include(include);
        }
        return Task.FromResult(queryable.AsEnumerable());
    }

}

