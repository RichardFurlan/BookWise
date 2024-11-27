using System.Drawing;
using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Rating.GetRatingsByBookId;

public record GetRatingsByBookIdQuery(int BookId, string Search, int Page, int Size) : IRequest<ResultViewModel<List<RatingItemViewModel>>>;