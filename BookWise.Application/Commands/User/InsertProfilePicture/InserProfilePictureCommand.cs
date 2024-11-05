using BookWise.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookWise.Application.Commands.User.InsertProfilePicture;

public record InserProfilePictureCommand(int UserId, IFormFile File) : IRequest<ResultViewModel>;