using BookWise.Application.DTOs;
using BookWise.Application.Queries.Shared;

namespace BookWise.Application.Queries.Publisher.GetPublisherById;

public record PublisherViewModel(
    int Id,
    string Name,
    AddressViewModel Address,
    List<string> Books
)
{
    public static PublisherViewModel FromEntity(Core.Entities.Publisher entity)
        => new(
            entity.Id,
            entity.Name,
            AddressViewModel.FromValueObject(entity.Address),
            entity.Books.Select(b => b.Title).ToList()
        );
}