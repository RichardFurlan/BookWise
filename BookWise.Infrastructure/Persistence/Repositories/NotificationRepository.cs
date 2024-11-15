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

    public async Task<Notification?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetSingleByConditionAsync(n => n.Id == id);
    }

    public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int id)
    {
        return await _genericRepository.GetByCondition(n => n.UserId == id).ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetByReadStatusAsync(bool isRead = false)
    {
        return await _genericRepository
                    .GetByCondition(n => n.IsRead == isRead)
                    .ToListAsync();
    }

    public void Update(Notification notification)
    {
        _genericRepository.Update(notification);
    }
}