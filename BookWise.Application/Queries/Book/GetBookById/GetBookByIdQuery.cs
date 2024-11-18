using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Book.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<ResultViewModel<BookViewModel>>;