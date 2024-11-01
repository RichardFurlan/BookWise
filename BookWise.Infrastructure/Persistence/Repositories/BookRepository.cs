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

    public Task<IQueryable<Book>> GetPaginatedAsync(string search, int page, int size)
    {
        throw new NotImplementedException();
    }

    public async Task<Book?> GetWithDetailsByIdAsync(int id)
    {
       return await _context.Books
           .Include(b => b.Ratings)
           .ThenInclude(r => r.User)
           .Include(b => b.Loans)
           .ThenInclude(l => l.User)
           .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
       
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteAsync(id);
    }
}