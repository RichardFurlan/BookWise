using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly IGenericRepository<Publisher> _genericRepository;

    public PublisherRepository(IGenericRepository<Publisher> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(Publisher publisher)
    {
        await _genericRepository.AddAsync(publisher);
    }

    public async Task<Publisher?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _genericRepository.ExistsByIdAsync(id);
    }

    public async Task<IEnumerable<Publisher>> GetPaginatedAsync(string search, int page, int size)
    {
        return await _genericRepository
            .GetByCondition(p => p.Name.Contains(search))
            .Skip((page - 1 ) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteAsync(id);
    }

    public void Update(Publisher publisher)
    {
        _genericRepository.Update(publisher);
    }
}