namespace BookWise.Infrastructure.Services;

public class NotificationService : INotificationService
{
    public Task NotifyOverdueLoanAsync(int borrowerId, int bookId)
    {
        throw new NotImplementedException();
    }
}