using BookWise.Core.Repositories;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookWiseDbContext _context;

    public UnitOfWork(BookWiseDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}