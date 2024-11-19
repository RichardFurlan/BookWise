using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Rating.GetRatingById;

public record GetRatingByIdQuery(int Id) : IRequest<ResultViewModel<RatingViewModel>>;