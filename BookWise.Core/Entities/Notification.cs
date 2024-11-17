namespace BookWise.Core.Entities;

public class Notification : BaseEntity
{
    public Notification(string content, int userId)
    {
        Content = content;
        UserId = userId;
        IsRead = false;
    }

    public string Content { get; private set; }
    public bool IsRead { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }

    public bool MarkAsRead()
    {
        if (IsRead) return false;
        IsRead = true;
        return true;
    }
    
    public bool MarkAsUnread()
    {
        if (!IsRead) return false;
        IsRead = false;
        return true;
    }
}