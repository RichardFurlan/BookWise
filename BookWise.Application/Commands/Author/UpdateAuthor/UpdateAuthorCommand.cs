using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Author.UpdateAuthor;

public record UpdateAuthorCommand(int AuthorId, string FullName, string Biography) : IRequest<ResultViewModel>;