using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Commands.Notification.InsertNotification;

public record InsertNotificationCommand(string Content, int UserId) : IRequest<ResultViewModel<int>>
{
    public Core.Entities.Notification ToEntity()
        => new(Content, UserId);
}
