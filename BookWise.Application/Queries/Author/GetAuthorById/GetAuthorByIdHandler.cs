using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Author.GetAuthorById;

public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, ResultViewModel<AuthorViewModel>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<ResultViewModel<AuthorViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id);
        if (author is null)
        {
            return ResultViewModel<AuthorViewModel>.Error("Autor não encontrado");
        }

        var model = AuthorViewModel.FromEntity(author);
        
        return ResultViewModel<AuthorViewModel>.Success(model);
    }
}