using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IPublisherRepository
{
    Task AddAsync(Publisher publisher);
    Task<Publisher?> GetByIdAsync(int id);
    Task<bool> ExistsByIdAsync(int id);
    Task<IEnumerable<Publisher>> GetPaginatedAsync(string search, int page, int size);
    Task DeleteAsync(int id);
    void Update(Publisher publisher);
}