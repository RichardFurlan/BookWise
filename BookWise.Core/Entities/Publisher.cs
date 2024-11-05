using BookWise.Core.ValueObjects;

namespace BookWise.Core.Entities;

public class Publisher : BaseEntity
{
    public Publisher(string name, Address address)
    {
        Name = name;
        Address = address;

        Books = [];
    }

    public string Name { get; private set; }
    public Address Address { get; private set; }
    public List<Book> Books { get; private set; }
}