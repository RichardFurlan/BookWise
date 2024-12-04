using BookWise.Application.DTOs;
using BookWise.Application.Queries.Loan.Shared;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoansByBook;

public record GetLoansByBookQuery(int BookId) : IRequest<ResultViewModel<List<LoanItemViewModel>>>;