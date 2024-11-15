using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Rating.Insert;

public record InsertRatingCommand(int RatingValue, string Content, int UserId, int BookId)
    : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Rating ToEntity()
        => new(RatingValue, Content, UserId, BookId);
}
