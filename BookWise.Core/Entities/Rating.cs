namespace BookWise.Core.Entities;

public class Rating : BaseEntity
{
    public Rating(int ratingValue, string content, int userId, int bookId)
    {
        RatingValue = ratingValue;
        Content = content;
        UserId = userId;
        BookId = bookId;
    }

    public int RatingValue { get; private set; }
    public string Content { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public int BookId { get; private set; }
    public Book Book { get; private set; }
    
}