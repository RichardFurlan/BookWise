using System.Linq.Expressions;
using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByConditionWithId(Expression<Func<T, bool>> expression);
    IQueryable<T> GetByIdQueryable(int id);
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression); 
    Task<bool> ExistsByIdAsync(int id);
    Task AddAsync(T entity);
    Task DeleteAsync(int id);
    void Update(T entity);
}