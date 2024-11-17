using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Notification.MarkAsUnread;

public class MarkAsUnreadHandler : IRequestHandler<MarkAsUnreadCommand, ResultViewModel>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkAsUnreadHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(MarkAsUnreadCommand request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetByIdAsync(request.Id);

        if (notification is null)
        {
            return ResultViewModel.Error("Notificação não encontrada");
        }
        
        if (!notification.MarkAsUnread())
        {
            return ResultViewModel.Error("A notificação já esta marcada como não lida.");
        }
        
        _notificationRepository.Update(notification);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel.Success();
    }
}