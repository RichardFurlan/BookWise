using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly IGenericRepository<Notification> _genericRepository;

    public NotificationRepository(IGenericRepository<Notification> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(Notification notification)
    {
        await _genericRepository.AddAsync(notification);
    }

    public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int id)
    {
        return await _genericRepository.GetByCondition(n => n.UserId == id).ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetByReadStatusAsync(bool isRead)
    {
        return await _genericRepository.GetByCondition(n => n.IsRead).ToListAsync();
    }
}