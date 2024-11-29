using BookWise.Core.Exceptions;

namespace BookWise.Core.ValueObjects;

public record Address(string Street, string City, string State, string ZipCode, string Country)
{
    public Address Validate()
    {
        if (string.IsNullOrWhiteSpace(Street))
            throw new DomainException("O campo Rua não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(City))
            throw new DomainException("O campo Cidade não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(State))
            throw new DomainException("O campo Estado não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(ZipCode))
            throw new DomainException("O campo CEP não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(Country))
            throw new DomainException("O campo País não pode ser vazio.");

        return this;
    }
};