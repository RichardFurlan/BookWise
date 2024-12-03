using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Loan.CancelLoan;

public record CancelLoanCommand(int LoanId) : IRequest<ResultViewModel>;
