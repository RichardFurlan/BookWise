namespace BookWise.Application.Queries.Book.GetAllBooks;

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
    public static BookItemViewModel FromEntity(Core.Entities.Book entity)
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