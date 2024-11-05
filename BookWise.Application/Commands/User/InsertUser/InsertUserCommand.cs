using BookWise.Application.DTOs;
using BookWise.Infrastructure.Services;
using MediatR;

namespace BookWise.Application.Commands.User.InsertUser;

public record InsertUserCommand(
    string FullName,
    string Email,
    string Password,
    string PasswordConfirm,
    DateTime BirthDate) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.User ToEntity(IAuthService authService)
    {
        var hashedPassword = authService.ComputeSha256Hash(Password);
        return new Core.Entities.User(FullName, Email, hashedPassword, BirthDate);
    }
}