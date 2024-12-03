using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using BookWise.Infrastructure.Services;
using MediatR;

namespace BookWise.Application.Commands.Loan.NotifyLoanOverdue;

public class NotifyLoanOverdueHandler : IRequestHandler<NotifyLoanOverdueCommand, ResultViewModel>
{
    private readonly ILoanRepository _loanRepository;
    private readonly INotificationService _notificationService;

    public NotifyLoanOverdueHandler(INotificationService notificationService, ILoanRepository loanRepository)
    {
        _notificationService = notificationService;
        _loanRepository = loanRepository;
    }

    public async Task<ResultViewModel> Handle(NotifyLoanOverdueCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId);
        if (loan == null)
            return ResultViewModel.Error("Empréstimo não encontrado.");
        
        if (!loan.IsOverdue())
            return ResultViewModel.Error("O empréstimo ainda não está atrasado.");
        
        try
        {
            await _notificationService.NotifyOverdueLoanAsync(loan.BorrowerId, loan.Id);
            return ResultViewModel.Success();
        }
        catch (Exception ex)
        {
            return ResultViewModel.Error("Erro ao notificar atraso: " + ex.Message);
        }
    }
}