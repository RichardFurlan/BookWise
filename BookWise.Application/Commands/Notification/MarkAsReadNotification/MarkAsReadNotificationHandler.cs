using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Notification.MarkAsReadNotification;

public class MarkAsReadNotificationHandler : IRequestHandler<MarkAsReadNotificationCommand, ResultViewModel>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkAsReadNotificationHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(MarkAsReadNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetByIdAsync(request.Id);

        if (notification is null)
        {
            return ResultViewModel.Error("Notificação não encontrada");
        }
        
        if (!notification.MarkAsRead())
        {
            return ResultViewModel.Error("A notificação já está marcada como lida.");
        }

        _notificationRepository.Update(notification);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel.Success();
    }
}