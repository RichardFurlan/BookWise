using BookWise.Core.Enum;

namespace BookWise.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string isbn, DateTime publicationDate, int edition, int publisherId, EnumLenguage lenguage, EnumBookStatus status, int numberOfPage) : base()
    {
        Title = title;
        Isbn = isbn;
        PublicationDate = publicationDate;
        Edition = edition;
        PublisherId = publisherId;
        Lenguage = lenguage;
        Status = status;
        NumberOfPage = numberOfPage;
        
        
        RatingAverage = 0.0f;
        RatingQuantity = 0;
        Ratings = [];
        Loans = [];
        Authors = [];
    }

    public string Title { get; private set; }
    public string Isbn { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public int Edition { get; private set; }
    public int PublisherId { get; private set; }
    public Publisher Publisher { get; private set; }
    public EnumLenguage Lenguage { get; private set; }
    public EnumBookStatus Status { get; private set; }
    public int NumberOfPage { get; private set; }
    public float RatingAverage { get; private set; }
    public int RatingQuantity { get; private set; }
    public List<Rating> Ratings { get; private set; }
    
    public List<Loan> Loans { get; private set; }
    public List<Author> Authors { get; private set; }
    
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
    
    public void AddAuthor(Author author)
    {
        if (!Authors.Contains(author))
            Authors.Add(author);
    }

    // #Todo: Analisar a regra para Update
    public void UpdateDetails(string title, string isbn, int edition, DateTime publicationDate, EnumLenguage lenguage,
        int numberOfPages )
    {
        Title = title;
        Isbn = isbn;
        Edition = edition;
        PublicationDate = publicationDate;
        Lenguage = lenguage;
        NumberOfPage = numberOfPages;
    }
}