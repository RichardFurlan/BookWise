using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Publisher.UpdatePublisher;

public record UpdatePublisherCommand(
    int PublisherId,
    string Name, 
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country
    ) : IRequest<ResultViewModel>;