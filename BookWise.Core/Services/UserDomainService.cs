using BookWise.Core.Entities;
using BookWise.Core.Exceptions;
using BookWise.Core.ValueObjects;

namespace BookWise.Core.Services;

public class UserDomainService
{
    public void UpdateUser(
        User user,
        string newFullName,
        DateTime newBirthDate,
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        if (string.IsNullOrWhiteSpace(newFullName))
            throw new DomainException("O nome do usuário não pode ser vazio.");
        
        if (newBirthDate == default)
            throw new DomainException("A data de nascimento não pode ser inválida.");
        
        var address = new Address(street, city, state, zipCode, country).Validate();
        
        user.UpdateBirthDate(newBirthDate);
        user.UpdateFullName(newFullName);
        user.UpdateAddress(address);
    }
}