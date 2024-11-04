using System.Linq.Expressions;
using BookWise.Core.Entities;
using BookWise.Core.Enum;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly IGenericRepository<Loan> _genericRepository;

    public LoanRepository(IGenericRepository<Loan> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(Loan loan)
    {
        await _genericRepository.AddAsync(loan);
    }

    public async Task<Loan?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetSingleByConditionAsync(l => l.Id == id);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _genericRepository.ExistsByIdAsync(id);
    }

    public async Task<IEnumerable<Loan>> GetLoansByFilter(DateTime startDate, DateTime endDate, decimal minValue, decimal maxValue, EnumLoanStatus status)
    {
        Expression<Func<Loan, bool>> filter = 
            l =>
                l.LoanDate >= startDate &&
                l.ReturnDate <= endDate &&
                l.Value >= minValue &&
                l.Value <= maxValue &&
                l.Status == status;
        
        var query = _genericRepository.GetByCondition(filter);

        query = query
                    .Include(l => l.User)
                    .Include(l => l.Book);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Loan>> GetPaginatedAsync(string search, int page, int size)
    {
        return await _genericRepository
            .GetByCondition(l => l.Book.Title.Contains(search) || l.User.FullName.Contains(search))
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<Loan?> GetWithDetailsByIdAsync(int id)
    {
        return await _genericRepository
            .GetByCondition(l => l.Id == id)
            .Include(l => l.User)
            .Include(l => l.Book)
            .SingleOrDefaultAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteAsync(id);
    }
}