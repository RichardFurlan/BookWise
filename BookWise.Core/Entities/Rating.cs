namespace BookWise.Core.Entities;

public class Rating : BaseEntity
{
    public int RatingValue { get; private set; }
    public string Content { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }
    
}