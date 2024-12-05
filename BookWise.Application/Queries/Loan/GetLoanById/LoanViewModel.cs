using BookWise.Core.Enum;

namespace BookWise.Application.Queries.Loan.GetLoanById;

public record LoanViewModel(
    DateTime LoanDate,
    DateTime? ReturnDate,
    DateTime DueDate,
    decimal Value,
    EnumLoanStatus Status,
    UserSummaryViewModel User,
    BookSummaryViewModel Book
    )
{
    public static LoanViewModel FromEntity(Core.Entities.Loan entity)
        => new(
            entity.LoanDate,
            entity.ReturnDate,
            entity.DueDate,
            entity.Value,
            entity.Status,
            new UserSummaryViewModel(entity.User.Id, entity.User.FullName),
            new BookSummaryViewModel(entity.BookId, entity.Book.Title)
        );
}