using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record PublisherViewModel(
    int Id,
    string Name,
    AddressViewModel Address,
    List<string> Books
)
{
    public static PublisherViewModel FromEntity(Publisher entity)
        => new(
            entity.Id,
            entity.Name,
            AddressViewModel.FromValueObject(entity.Address),
            entity.Books.Select(b => b.Title).ToList()
        );
}