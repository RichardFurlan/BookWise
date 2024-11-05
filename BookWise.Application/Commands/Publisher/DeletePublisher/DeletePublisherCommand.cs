using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Publisher.DeletePublisher;

public record DeletePublisherCommand(int Id) : IRequest<ResultViewModel>;