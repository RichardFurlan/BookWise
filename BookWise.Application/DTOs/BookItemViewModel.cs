using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record BookItemViewModel(
    int Id,
    string Title,
    List<string> AuthorsName,
    string PublisherName,
    DateTime PublicationDate,
    int RatingQuantity,
    float RatingAvarege
)
{
    public static BookItemViewModel FromEntity(Book entity)
        => new(
            entity.Id,
            entity.Title,
            entity.Authors.Select(a => a.FullName).ToList(),
            entity.Publisher.Name,
            entity.PublicationDate,
            entity.RatingQuantity,
            entity.RatingAverage
        );
}