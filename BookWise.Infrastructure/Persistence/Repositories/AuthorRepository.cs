using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly IGenericRepository<Author> _genericRepository;

    public AuthorRepository(IGenericRepository<Author> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(Author author)
    {
        await _genericRepository.AddAsync(author);
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetSingleByConditionAsync(p => p.Id == id);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _genericRepository.ExistsByIdAsync(id);
    }

    public async Task<IEnumerable<Author>> GetPaginatedAsync(string search, int page, int size)
    {
        return await _genericRepository
            .GetByCondition(p => string.IsNullOrEmpty(search) || p.Name.Contains(search))
            .Skip((page - 1 ) * size)
            .Take(size)
            .ToListAsync();;
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteAsync(id);
    }

    public void Update(Author author)
    {
        _genericRepository.Update(author);
    }
}