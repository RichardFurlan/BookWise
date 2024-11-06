using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Author.DeleteAuthor;

public record DeleteAuthorCommand(int Id) : IRequest<ResultViewModel>;
