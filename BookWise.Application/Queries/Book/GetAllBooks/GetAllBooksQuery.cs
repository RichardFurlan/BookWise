using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Book.GetAllBooks;

public record GetAllBooksQuery(string Search, int Page, int Size) : IRequest<ResultViewModel<List<BookItemViewModel>>>;