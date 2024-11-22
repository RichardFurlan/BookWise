using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Publisher.GetPublisherById;

public record GetPublisherByIdQuery(int Id) : IRequest<ResultViewModel<PublisherViewModel>>;