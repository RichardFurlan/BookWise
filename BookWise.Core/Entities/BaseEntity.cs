namespace BookWise.Core.Entities;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now.ToUniversalTime();
        UpdateAt = DateTime.Now.ToUniversalTime();
        IsDeleted = false;
        IsUpdated = false;
    }

    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
    public bool IsUpdated { get; private set; }
    public bool IsDeleted { get; private set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
        MarkAsUpdated();
    }

    public void MarkAsUpdated()
    {
        IsUpdated = true;
        UpdateAt = DateTime.UtcNow;
    }
}