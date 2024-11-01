using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> ExistsByIdAsync(int id);
    Task AddAsync(T entity);
    Task DeleteAsync(int id);
    void Update(T entity);
}