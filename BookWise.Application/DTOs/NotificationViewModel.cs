using BookWise.Application.Helpers;
using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record NotificationViewModel(
    int Id,
    string Content,
    DateTime CreatedAt,
    bool IsRead
)
{
    public static NotificationViewModel FromEntity(Notification entity)
        => new(
            entity.Id,
            entity.Content,
            DateTimeHelper.ConvertToBrasiliaTime(entity.CreatedAt),
            entity.IsRead
            );
}