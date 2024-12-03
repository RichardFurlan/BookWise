using BookWise.Core.Entities;
using BookWise.Core.Enum;
using BookWise.Core.Exceptions;

namespace BookWise.Core.Services;
// #TODO: Criar service para emprestimos
public class LoanDomainService
{
    public void CancelLoan(Loan loan)
    {
        if (loan.Status == EnumLoanStatus.Completed)
            throw new DomainException("Empréstimos concluídos não podem ser cancelados");
        
        loan.Cancel();
    }

    public void ExtendLoan(Loan loan, DateTime newDueDate)
    {
        if (newDueDate <= loan.DueDate)
            throw new DomainException("A nova data deve ser posterior à data atual de vencimento.");

        loan.ExtendDueDate(newDueDate);
    }
}