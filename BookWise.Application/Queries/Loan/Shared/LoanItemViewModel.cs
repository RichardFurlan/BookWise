using BookWise.Core.Enum;

namespace BookWise.Application.Queries.Loan.Shared;

public record LoanItemViewModel(
    int LoanId,
    int BorrowerId,
    int BookId,
    DateTime BorrowDate,
    DateTime ExpectedReturnDate,
    DateTime? ActualReturnDate,
    string BookTitle,
    string UserFullName,
    EnumLoanStatus Status
)
{
    public static LoanItemViewModel FromEntity(Core.Entities.Loan entity)
        => new(
            entity.Id,
            entity.BorrowerId,
            entity.BookId,
            entity.LoanDate,
            entity.DueDate,
            entity.ReturnDate,
            entity.Book?.Title ?? "Desconhecido",
            entity.User?.FullName ?? "Desconhecido",
            entity.Status
        );
}