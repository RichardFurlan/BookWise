using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<Book?> GetByIdAsync(int id);
    void Update(Book book);
    Task<bool> ExistsByIdAsync(int id);
    Task<IQueryable<Book>> GetPaginatedAsync(string search, int page, int size);
    Task<Book?> GetWithDetailsByIdAsync(int id);
    Task DeleteAsync(int id);
}