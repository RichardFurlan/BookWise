using BookWise.Core.Enum;

namespace BookWise.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, List<Author> authors, string isbn, DateTime yearOfPublication, int edition, int publisherId, EnumLenguage lenguage, EnumBookStatus status, int numberOfPage) : base()
    {
        Title = title;
        Authors = authors;
        Isbn = isbn;
        YearOfPublication = yearOfPublication;
        Edition = edition;
        PublisherId = publisherId;
        Lenguage = lenguage;
        Status = status;
        NumberOfPage = numberOfPage;
        
        
        RatingAverage = null;
        RatingQuantity = 0;
        Ratings = [];
        Loans = [];
    }

    public string Title { get; private set; }
    public List<Author> Authors { get; private set; }
    public string Isbn { get; private set; }
    public DateTime YearOfPublication { get; private set; }
    public int Edition { get; private set; }
    public int PublisherId { get; private set; }
    public Publisher Publisher { get; private set; }
    public EnumLenguage Lenguage { get; private set; }
    public EnumBookStatus Status { get; private set; }
    public int NumberOfPage { get; private set; }
    public float? RatingAverage { get; private set; }
    public int RatingQuantity { get; private set; }
    public List<Rating> Ratings { get; private set; }
    
    public List<Loan> Loans { get; private set; }
    
    // #Todo: Adicionar regra na classe Service
    // public void RentedBook(User user)
    // {
    //     if (Status == EnumBookStatus.Available && CurrentRenter is null)
    //     {
    //         CurrentRenter = user;
    //         Status = EnumBookStatus.Rented;
    //     }
    //     else
    //     {
    //         throw new InvalidOperationException("O livro já está alugado.");
    //     }
    // }
    //
    // public void ReturnBook()
    // {
    //     if (Status == EnumBookStatus.Rented && CurrentRenter != null)
    //     {
    //         RentalHistory.Add(CurrentRenter);
    //         CurrentRenter = null;
    //         Status = EnumBookStatus.Available;
    //     }
    //     else
    //     {
    //         throw new InvalidOperationException("O livro não está alugado.");
    //     }
    // }
    
}