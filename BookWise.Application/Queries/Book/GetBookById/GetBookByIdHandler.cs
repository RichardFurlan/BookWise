using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Book.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetWithDetailsByIdAsync(request.Id);
        if (book is null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro não encontrado");
        }

        var model = BookViewModel.FromEntity(book);

        return ResultViewModel<BookViewModel>.Success(model);
    }
}