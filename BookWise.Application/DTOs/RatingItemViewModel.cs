using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record RatingItemViewModel(
    int Id,
    int RatingValue,
    string Content,
    string FullNameUser
)
{
    public static RatingItemViewModel FromEntity(Rating entity)
        => new(
            entity.Id,
            entity.RatingValue,
            entity.Content,
            entity.User.FullName
        );
};