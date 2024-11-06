using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Author.InsertAuthor;

public class InsertAuthorHandler : IRequestHandler<InsertAuthorCommand, ResultViewModel<int>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InsertAuthorHandler(IAuthorRepository authorRepositoryRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepositoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<int>> Handle(InsertAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = request.ToEntity();

        await _authorRepository.AddAsync(author);

        await _unitOfWork.SaveChangesAsync();

        return ResultViewModel<int>.Success(author.Id);
    }
}