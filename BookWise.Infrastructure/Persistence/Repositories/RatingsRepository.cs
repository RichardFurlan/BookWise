using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class RatingsRepository : IRatingRepository
{
    private readonly IGenericRepository<Rating> _genericRepository;

    public RatingsRepository(IGenericRepository<Rating> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(Rating rating)
    {
        await _genericRepository.AddAsync(rating);
    }

    public async Task<IEnumerable<Rating>> GetRatingsByBookIdAsync(int bookId, int page, int size)
    {
        return await _genericRepository
            .GetByCondition(r => r.IdBook == bookId)
            .Skip((page -1) * size)
            .Take(size)
            .ToListAsync();
    }

    public Task<bool> ExistsByIdAsync(int id)
    {
        return _genericRepository.ExistsByIdAsync(id);
    }
}