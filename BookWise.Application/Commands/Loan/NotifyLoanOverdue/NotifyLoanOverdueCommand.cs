using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Loan.NotifyLoanOverdue;

public record NotifyLoanOverdueCommand(int LoanId) : IRequest<ResultViewModel>;