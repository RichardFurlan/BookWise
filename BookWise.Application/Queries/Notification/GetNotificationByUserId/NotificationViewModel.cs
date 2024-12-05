using BookWise.Application.Helpers;

namespace BookWise.Application.Queries.Notification.GetNotificationByUserId;

public record NotificationViewModel(
    int Id,
    string Content,
    DateTime CreatedAt,
    bool IsRead
)
{
    public static NotificationViewModel FromEntity(Core.Entities.Notification entity)
        => new(
            entity.Id,
            entity.Content,
            DateTimeHelper.ConvertToBrasiliaTime(entity.CreatedAt),
            entity.IsRead
            );
}