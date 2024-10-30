namespace BookWise.Core.Entities;

public class Author : BaseEntity
{
    public Author(string name, string biography) : base()
    {
        Name = name;
        Biography = biography;
        Books = [];
    }

    public string Name { get; private set; }
    public string Biography { get; private set; }
    public List<Book> Books { get; private set; }
}