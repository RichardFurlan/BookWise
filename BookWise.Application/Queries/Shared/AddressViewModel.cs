using BookWise.Core.ValueObjects;

namespace BookWise.Application.Queries.Shared;

public record AddressViewModel(
    string Street, 
    string City, 
    string State, 
    string ZipCode, 
    string Country
)
{
    public static AddressViewModel FromValueObject(Address address)
        => new(
            address.Street,
            address.City,
            address.State,
            address.ZipCode,
            address.Country
        );
}