using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Notification.DeleteNotification;

public record DeleteNotificationCommand(int Id) : IRequest<ResultViewModel>;