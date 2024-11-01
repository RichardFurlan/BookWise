using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface INotificationRepository
{
    Task AddAsync(Notification notification);
    Task<IQueryable<Notification>> GetNotificationsByUserId(int id);
    Task<IQueryable<Notification>> GetByReadStatusAsync(bool isRead);
    Task DeleteAsync(int id);
}