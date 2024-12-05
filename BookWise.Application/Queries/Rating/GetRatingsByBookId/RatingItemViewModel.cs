namespace BookWise.Application.Queries.Rating.GetRatingsByBookId;

public record RatingItemViewModel(
    int Id,
    int RatingValue,
    string Content,
    string FullNameUser
)
{
    public static RatingItemViewModel FromEntity(Core.Entities.Rating entity)
        => new(
            entity.Id,
            entity.RatingValue,
            entity.Content,
            entity.User.FullName
        );
};