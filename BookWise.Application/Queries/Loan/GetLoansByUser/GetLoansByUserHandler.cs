using BookWise.Application.DTOs;
using BookWise.Application.Queries.Loan.GetLoansByBook;
using BookWise.Application.Queries.Loan.Shared;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoansByUser;

public class GetLoansByUserHandler : IRequestHandler<GetLoansByUserQuery, ResultViewModel<List<LoanItemViewModel>>>
{
    private readonly ILoanRepository _loanRepository;

    public GetLoansByUserHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ResultViewModel<List<LoanItemViewModel>>> Handle(GetLoansByUserQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetLoansByUserAsync(request.UserId);
        var model = loans.Select(LoanItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<LoanItemViewModel>>.Success(model);
    }
}