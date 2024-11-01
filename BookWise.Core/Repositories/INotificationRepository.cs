using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface INotificationRepository
{
    Task AddAsync(Notification notification);
    Task<IEnumerable<Notification>> GetNotificationsByUserId(int id);
    Task<IEnumerable<Notification>> GetByReadStatusAsync(bool isRead);
    Task DeleteAsync(int id);
}