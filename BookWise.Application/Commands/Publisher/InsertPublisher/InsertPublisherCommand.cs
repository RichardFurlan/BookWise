using BookWise.Application.DTOs;
using BookWise.Core.ValueObjects;
using MediatR;

namespace BookWise.Application.Commands.Publisher.InsertPublisher;

public record InsertPublisherCommand(
    string Name,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Publisher ToEntity()
        => new(Name, new Address(Street, City, State, ZipCode, Country));
};