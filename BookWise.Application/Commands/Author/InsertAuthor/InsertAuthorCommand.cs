using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Author.InsertAuthor;

public record InsertAuthorCommand(string Name, string Biography) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Author ToEntity()
        => new (Name, Biography);
};