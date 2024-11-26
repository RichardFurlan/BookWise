using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Notification.GetNotificationByUserId;

public class GetNotificationByUserIdHandler : IRequestHandler<GetNotificationByUserIdQuery, ResultViewModel<List<NotificationViewModel>>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationByUserIdHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<ResultViewModel<List<NotificationViewModel>>> Handle(GetNotificationByUserIdQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.GetNotificationsByUserId(request.UserId);

        var model = notifications
            .Select(NotificationViewModel.FromEntity)
            .ToList();
        
        
        return ResultViewModel<List<NotificationViewModel>>.Success(model);
    }
}