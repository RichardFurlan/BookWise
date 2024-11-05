using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.User.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<ResultViewModel<LoginUserViewModel>>;