using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Author.GetAuthorById;

public record GetAuthorByIdQuery(int Id) : IRequest<ResultViewModel<AuthorViewModel>>;