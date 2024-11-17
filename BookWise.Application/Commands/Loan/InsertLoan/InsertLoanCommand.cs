using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Loan.InsertLoan;

public record InsertLoanCommand(
    decimal Value, 
    int UserId, 
    int BookId, 
    int LoanDurationDays) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Loan ToEntity()
        => new(Value, UserId, BookId, LoanDurationDays);
};