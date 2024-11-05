using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IAuthorRepository
{
    Task AddAsync(Author author);
    Task<Author?> GetByIdAsync(int id);
    Task<bool> ExistsByIdAsync(int id);
    Task<IEnumerable<Author>> GetPaginatedAsync(string search, int page, int size);
    void Update(Author author);
}