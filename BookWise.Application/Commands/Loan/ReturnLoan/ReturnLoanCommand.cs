using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Loan.ReturnLoan;

public record ReturnLoanCommand(int LoanId): IRequest<ResultViewModel>;