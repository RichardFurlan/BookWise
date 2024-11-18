using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.User.GetUserById;

public record GetUserByIdQuery(int Id) : IRequest<ResultViewModel<UserViewModel>>;