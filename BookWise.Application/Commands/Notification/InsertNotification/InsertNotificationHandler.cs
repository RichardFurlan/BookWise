using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Notification.InsertNotification;

public class InsertNotificationHandler : IRequestHandler<InsertNotificationCommand, ResultViewModel<int>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public InsertNotificationHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertNotificationCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.ExistsByIdAsync(request.UserId);
        if (!userExists)
        {
            return (ResultViewModel<int>)ResultViewModel.Error("Usuário não encontrado");
        }

        var notification = request.ToEntity();

        await _notificationRepository.AddAsync(notification);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(notification.Id);
    }
}