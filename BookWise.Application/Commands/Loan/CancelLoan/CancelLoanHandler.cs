using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.Loan.CancelLoan;

public class CancelLoanHandler : IRequestHandler<CancelLoanCommand, ResultViewModel>
{
    private readonly ILoanRepository _loanRepository;
    private readonly LoanDomainService _loanDomainService;
    private readonly IUnitOfWork _unitOfWork;

    public CancelLoanHandler(ILoanRepository loanRepository, LoanDomainService loanDomainService, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _loanDomainService = loanDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(CancelLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId);
        if (loan == null)
            return ResultViewModel.Error("Empréstimo não encontrado");

        try
        {
            _loanDomainService.CancelLoan(loan);
            _loanRepository.Update(loan);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
        catch (DomainException ex)
        {
            return ResultViewModel.Error("Erro ao cancelar empréstimo: " + ex.Message);
        }
        catch (Exception ex)
        {
            // TODO: Adicionar log 
            return ResultViewModel.Error("Um erro inesperado aconteceu");
        }
    }
}