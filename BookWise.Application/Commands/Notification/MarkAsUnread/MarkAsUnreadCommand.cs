using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Notification.MarkAsUnread;

public record MarkAsUnreadCommand(int Id) : IRequest<ResultViewModel>;