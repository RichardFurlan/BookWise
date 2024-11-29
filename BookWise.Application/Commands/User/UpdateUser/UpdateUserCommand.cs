using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.User.UpdateUser;

public record UpdateUserCommand(
    int UserId,
    string FullName,
    DateTime BirthDate,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country) : IRequest<ResultViewModel>;