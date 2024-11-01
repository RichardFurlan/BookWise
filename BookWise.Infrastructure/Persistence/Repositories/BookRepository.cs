using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IGenericRepository<Book> _genericRepository;
    private readonly BookWiseDbContext _context;
    
    public BookRepository(IGenericRepository<Book> genericRepository, BookWiseDbContext context)
    {
        _genericRepository = genericRepository;
        _context = context;
    }
    public async Task AddAsync(Book book)
    {
        await _genericRepository.AddAsync(book);
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public void Update(Book book)
    {
        _genericRepository.Update(book);
    }

    public Task<bool> ExistsByIdAsync(int id)
    {
        return _genericRepository.ExistsByIdAsync(id);
    }

    public async Task<IEnumerable<Book>> GetPaginatedAsync(string search, int page, int size)
    {
        return await _genericRepository
            .GetByCondition(b => b.Title.Contains(search))
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<Book?> GetWithDetailsByIdAsync(int id)
    {
        return await _genericRepository
            .GetByIdQueryable(id)
            .Include(b => b.Ratings)
            .ThenInclude(r => r.User)
            .Include(b => b.Loans)
            .ThenInclude(l => l.User)
            .SingleOrDefaultAsync();;
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteAsync(id);
    }
}