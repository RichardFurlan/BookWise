using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IRatingRepository
{
    Task AddAsync(Rating rating);
    Task<IQueryable<Rating>> GetRatingsByBookIdAsync(int bookId, int page, int size);
    Task<bool> ExistsByIdAsync(int id);
}