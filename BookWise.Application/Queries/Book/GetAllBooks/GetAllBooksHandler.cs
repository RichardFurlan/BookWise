using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Book.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookItemViewModel>>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetPaginatedAsync(request.Search, request.Page, request.Size);

        var model = books.Select(BookItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Success(model);
    }
}