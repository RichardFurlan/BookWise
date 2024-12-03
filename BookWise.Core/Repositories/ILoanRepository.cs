using BookWise.Core.Entities;
using BookWise.Core.Enum;

namespace BookWise.Core.Repositories;

public interface ILoanRepository
{
    Task AddAsync(Loan loan);
    void Update(Loan loan);
    Task<Loan?> GetByIdAsync(int id);
    Task<bool> ExistsByIdAsync(int id);
    Task<IEnumerable<Loan>> GetLoansByFilter(
        DateTime startDate,
        DateTime endDate,
        decimal minValue,
        decimal maxValue,
        EnumLoanStatus status);

    Task<IEnumerable<Loan>> GetPaginatedAsync(string search, int page, int size);
    Task<Loan?> GetWithDetailsByIdAsync(int id);
}