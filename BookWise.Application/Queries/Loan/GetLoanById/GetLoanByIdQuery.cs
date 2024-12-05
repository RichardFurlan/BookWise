using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoanById;

public record GetLoanByIdQuery(int LoanId) : IRequest<ResultViewModel<LoanViewModel>>;