namespace BookWise.Core.Entities;

public class Author : BaseEntity
{
    public Author(string fullName, string biography) : base()
    {
        FullName = fullName;
        Biography = biography;
        Books = [];
    }

    public string FullName { get; private set; }
    public string Biography { get; private set; }
    public List<Book> Books { get; private set; }
}