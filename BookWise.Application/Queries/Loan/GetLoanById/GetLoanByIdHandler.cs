using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Loan.GetLoanById;

public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
{
    private readonly ILoanRepository _loanRepository;

    public GetLoanByIdHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdWithDetailsAsync(request.LoanId);
        if (loan == null)
            return ResultViewModel<LoanViewModel>.Error("Empréstimo não localizado");

        var model = LoanViewModel.FromEntity(loan);
        return ResultViewModel<LoanViewModel>.Success(model);
    }
}