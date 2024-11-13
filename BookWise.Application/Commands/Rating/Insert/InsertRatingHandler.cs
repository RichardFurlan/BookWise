using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Rating.Insert;

public class InsertRatingHandler : IRequestHandler<InsertRatingCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InsertRatingHandler(IUserRepository userRepository, IBookRepository bookRepository, IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<int>> Handle(InsertRatingCommand request, CancellationToken cancellationToken)
    {
        if (!await _bookRepository.ExistsByIdAsync(request.BookId))
        {
            return ResultViewModel<int>.Error("O livro especificado não foi encontrado.");
        }

        if (!await _userRepository.ExistsByIdAsync(request.UserId))
        {
            return ResultViewModel<int>.Error("O usuario especificado não foi encontrado.");
        }

        var rating = request.ToEntity();

        await _ratingRepository.AddAsync(rating);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(rating.Id);
    }
}