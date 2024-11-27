using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Rating.GetRatingsByBookId;

public class GetRatingsByBookId : IRequestHandler<GetRatingsByBookIdQuery, ResultViewModel<List<RatingItemViewModel>>>
{
    private readonly IRatingRepository _ratingRepository;

    public GetRatingsByBookId(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<ResultViewModel<List<RatingItemViewModel>>> Handle(GetRatingsByBookIdQuery request, CancellationToken cancellationToken)
    {
        var ratings = await _ratingRepository.GetRatingsByBookIdAsync(request.BookId, request.Search, request.Page, request.Size);

        var model = ratings.Select(RatingItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<RatingItemViewModel>>.Success(model);
    }
}