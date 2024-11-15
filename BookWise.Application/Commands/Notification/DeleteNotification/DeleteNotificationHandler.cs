using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Notification.DeleteNotification;

public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, ResultViewModel>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetByIdAsync(request.Id);
        
        if (notification is null)
        {
            return ResultViewModel.Error("Notificação não encontrado");
        }
        
        notification.SetAsDeleted();
        
        _notificationRepository.Update(notification);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel.Success();

    }
}