using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Book.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<ResultViewModel>;