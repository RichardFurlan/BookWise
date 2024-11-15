using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Notification.MarkAsReadNotification;

public record MarkAsReadNotificationCommand(int Id) : IRequest<ResultViewModel>;