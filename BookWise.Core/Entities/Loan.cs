using BookWise.Core.Enum;

namespace BookWise.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(decimal value, int userId, int bookId, int loanDurationDays = 15)
    {
        LoanDate = DateTime.Now.ToUniversalTime();
        DueDate = LoanDate.AddDays(loanDurationDays); 
        Value = value;
        UserId = userId;
        BookId = bookId;
        Status = EnumLoanStatus.Active;
    }

    public DateTime LoanDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Value { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public int BookId { get; private set; }
    public Book Book { get; private set; }
    public EnumLoanStatus Status { get; private set; }

    public void CompleteLoan(DateTime returnDate)
    {
        if (returnDate < LoanDate)
        {
            throw new ArgumentException("A data de devolução não pode ser anterior à data do empréstimo.");
        }

        ReturnDate = returnDate;
        Status = EnumLoanStatus.Completed; 
    }

    public void Cancel() => Status = EnumLoanStatus.Canceled;
    
    
    /// <summary>
    /// Verifica se o empréstimo está atrasado.
    /// </summary>
    public bool IsOverdue() => ReturnDate == null && DateTime.Now > DueDate;

    public void ExtendDueDate(DateTime newDueDate) => DueDate = newDueDate;

    public void MarkAsReturned()
    {
        Status = EnumLoanStatus.Completed;
        ReturnDate = DateTime.Now.ToUniversalTime();
    }
}