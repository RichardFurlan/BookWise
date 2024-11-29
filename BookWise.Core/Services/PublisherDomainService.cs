using BookWise.Core.Entities;
using BookWise.Core.Exceptions;
using BookWise.Core.ValueObjects;

namespace BookWise.Core.Services;

public class PublisherDomainService
{
    public void UpdatePublisher(
        Publisher publisher, 
        string newName,
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new DomainException("O nome do usuário não pode ser vazio.");
        
        var address = new Address(street, city, state, zipCode, country).Validate();
        
        publisher.UpdateAddress(address);
        publisher.UpdateName(newName);
    }
}