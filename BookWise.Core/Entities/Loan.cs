namespace BookWise.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(DateTime loanDate, decimal value, DateTime returnDate)
    {
        if (returnDate < loanDate)
        {
            throw new ArgumentException("Return date cannot be earlier than loan date.");
        }
        LoanDate = loanDate;
        Value = value;
        ReturnDate = returnDate;
    }

    public DateTime LoanDate { get; private set; }
    public DateTime ReturnDate { get; set; }
    public decimal Value { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }
}