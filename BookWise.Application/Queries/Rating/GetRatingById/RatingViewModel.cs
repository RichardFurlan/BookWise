namespace BookWise.Application.Queries.Rating.GetRatingById;

public record RatingViewModel(
    int Id, 
    int RatingValue, 
    string Content, 
    int UserId,
    string? FullName,
    int BookId,
    string? BookTitle,
    float? RatingAverage,
    int? RatingQuantity
    )
{
    public static RatingViewModel FromEntity(Core.Entities.Rating entity) 
        => new(
            entity.Id, 
            entity.RatingValue, 
            entity.Content, 
            entity.UserId,
            entity.User?.FullName,
            entity.BookId,
            entity.Book?.Title,
            entity.Book?.RatingAverage,
            entity.Book?.RatingQuantity
        );
}