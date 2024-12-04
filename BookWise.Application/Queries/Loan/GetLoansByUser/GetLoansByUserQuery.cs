using BookWise.Application.DTOs;
using BookWise.Application.Queries.Loan.Shared;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoansByUser;

public record GetLoansByUserQuery(int UserId) : IRequest<ResultViewModel<List<LoanItemViewModel>>>;