using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface INotificationRepository
{
    Task AddAsync(Notification notification);
    Task<Notification?> GetByIdAsync(int id);
    Task<IEnumerable<Notification>> GetNotificationsByUserId(int id);
    Task<IEnumerable<Notification>> GetByReadStatusAsync(bool isRead);
    void Update(Notification notification);
}