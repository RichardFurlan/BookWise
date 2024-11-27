using BookWise.Application.DTOs;
using MediatR;

namespace BookWise.Application.Queries.Notification.GetNotificationByUserId;

public record GetNotificationByUserIdQuery(int UserId) : IRequest<ResultViewModel<List<NotificationViewModel>>>;