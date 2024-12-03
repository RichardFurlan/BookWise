namespace BookWise.Infrastructure.Services;

public interface INotificationService
{
    Task NotifyOverdueLoanAsync(int borrowerId, int bookId);
}