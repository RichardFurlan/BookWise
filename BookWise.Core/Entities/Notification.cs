namespace BookWise.Core.Entities;

public class Notification : BaseEntity
{
    public string Content { get; private set; }
    public bool IsRead { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
}