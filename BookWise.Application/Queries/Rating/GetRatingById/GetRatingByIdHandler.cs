using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Rating.GetRatingById;

public class GetRatingByIdHandler : IRequestHandler<GetRatingByIdQuery, ResultViewModel<RatingViewModel>>
{
    private readonly IRatingRepository _ratingRepository;

    public GetRatingByIdHandler(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<ResultViewModel<RatingViewModel>> Handle(GetRatingByIdQuery request, CancellationToken cancellationToken)
    {
        var rating = await _ratingRepository.GetWithDetailsByIdAsync(request.Id);
        if (rating is null)
        {
            return ResultViewModel<RatingViewModel>.Error("Avaliação não encontrado");
        }

        var model = RatingViewModel.FromEntity(rating);

        return ResultViewModel<RatingViewModel>.Success(model);
    }
}