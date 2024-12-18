using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IRatingRepository
{
    Task AddAsync(Rating rating);
    Task<Rating?> GetWithDetailsByIdAsync(int id);
    Task<IEnumerable<Rating>> GetRatingsByBookIdAsync(int bookId, string search, int page, int size);
    Task<bool> ExistsByIdAsync(int id);
}