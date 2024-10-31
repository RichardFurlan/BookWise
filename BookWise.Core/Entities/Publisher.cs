namespace BookWise.Core.Entities;

public class Publisher : BaseEntity
{
    public Publisher(string name, string address)
    {
        Name = name;
        Address = address;

        Books = [];
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public List<Book> Books { get; private set; }
}