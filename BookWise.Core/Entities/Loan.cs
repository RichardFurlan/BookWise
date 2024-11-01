using BookWise.Core.Enum;

namespace BookWise.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(DateTime loanDate, decimal value, DateTime returnDate, int userId, int bookId)
    {
        if (returnDate < loanDate)
        {
            throw new ArgumentException("Return date cannot be earlier than loan date.");
        }
        LoanDate = loanDate;
        Value = value;
        ReturnDate = returnDate;
        UserId = userId;
        BookId = bookId;
    }

    public DateTime LoanDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public decimal Value { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public int BookId { get; private set; }
    public Book Book { get; private set; }
    public EnumLoanStatus Status { get; private set; }
}