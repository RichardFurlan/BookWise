using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Loan.ExtendLoan;

public record ExtendLoanCommand(int LoanId, DateTime NewDueDate) : IRequest<ResultViewModel>;