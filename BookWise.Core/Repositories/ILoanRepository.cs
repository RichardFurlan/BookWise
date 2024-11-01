using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface ILoanRepository
{
    Task AddAsync(Loan loan);
    Task<Loan?> GetByIdAsync(int id);
    Task<bool> ExistsByIdAsync(int id);
    Task<IQueryable<Loan>> GetPaginatedAsync(string search, int page, int size);
    Task<Loan?> GetWithDetailsByIdAsync(int id);
    Task DeleteAsync(int id);
}