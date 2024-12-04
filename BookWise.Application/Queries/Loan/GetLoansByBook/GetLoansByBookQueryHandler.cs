using BookWise.Application.DTOs;
using BookWise.Application.Queries.Loan.Shared;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoansByBook;

public class GetLoansByBookQueryHandler : IRequestHandler<GetLoansByBookQuery, ResultViewModel<List<LoanItemViewModel>>>
{
    private readonly ILoanRepository _loanRepository;

    public GetLoansByBookQueryHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ResultViewModel<List<LoanItemViewModel>>> Handle(GetLoansByBookQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetLoansByBookAsync(request.BookId);
        var model = loans.Select(LoanItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<LoanItemViewModel>>.Success(model);
    }
}