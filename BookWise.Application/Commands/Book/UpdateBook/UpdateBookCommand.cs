using BookWise.Application.DTOs;
using BookWise.Core.Enum;
using MediatR;

namespace BookWise.Application.Commands.Book.UpdateBook;

public record UpdateBookCommand(
    int Id, 
    string Title,
    string Isbn,
    DateTime PublicationDate,
    int Edition,
    EnumLenguage Lenguage,
    int NumberOfPage) : IRequest<ResultViewModel>;