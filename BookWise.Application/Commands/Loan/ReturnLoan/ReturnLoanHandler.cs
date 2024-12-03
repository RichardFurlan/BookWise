using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Loan.ReturnLoan;

public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, ResultViewModel>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReturnLoanHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId);
        if (loan == null )
            return ResultViewModel.Error("Empréstimo não encontrado.");

        try
        {
            loan.MarkAsReturned();
            _loanRepository.Update(loan);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ResultViewModel.Success();
        }
        catch (DomainException ex)
        {
            Console.WriteLine(ex);
            return ResultViewModel.Error("Erro ao extender empréstimo: " + ex.Message);
        }
        catch (Exception ex)
        {
            // TODO: Adicionar log 
            return ResultViewModel.Error("Um erro inesperado aconteceu");
        }
    }
}