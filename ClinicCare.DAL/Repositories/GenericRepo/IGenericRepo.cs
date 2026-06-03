using System.Linq.Expressions;
using Clinic.Care.DAL.QueryHandler;

namespace Clinic.Care.DAL.Repositories.GenericRepo;

public interface IGenericRepo<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync(
        Query query,
        Expression<Func<T, object>>? include);

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}