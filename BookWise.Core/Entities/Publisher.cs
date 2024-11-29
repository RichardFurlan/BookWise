using BookWise.Core.ValueObjects;

namespace BookWise.Core.Entities;

public class Publisher : BaseEntity
{
    public Publisher(string name, Address address)
    {
        Name = name;
        Address = address.Validate();

        Books = [];
    }

    public string Name { get; private set; }
    public Address Address { get; private set; }
    public List<Book> Books { get; private set; }
    
    #region Updates
    public void UpdateName(string newName)
    => Name = newName;
    
    public void UpdateAddress(Address newAddress)
    => Address = newAddress;
    
    #endregion
}