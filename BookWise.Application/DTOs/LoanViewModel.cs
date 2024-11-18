using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record LoanViewModel(
    DateTime LoanDate,
    DateTime? ReturnDate,
    string UserName
    )
{
    public static LoanViewModel FromEntity(Loan entity)
        => new(
            entity.LoanDate,
            entity.ReturnDate,
            entity.User.FullName
        );
}