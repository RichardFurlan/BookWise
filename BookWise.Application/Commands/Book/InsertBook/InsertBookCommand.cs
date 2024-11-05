using BookWise.Application.DTOs;
using BookWise.Core.Enum;
using MediatR;

namespace BookWise.Application.Commands.Book.InsertBook;

public record InsertBookCommand(
    string Title,
    string Isbn,
    DateTime YearOfPublication,
    int Edition,
    int PublisherId,
    EnumLenguage Lenguage,
    EnumBookStatus Status,
    int NumberOfPages,
    List<int> AuthorsId) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Book ToEntity()
        => new(Title, Isbn, YearOfPublication, Edition, PublisherId, Lenguage, Status, NumberOfPages);
}