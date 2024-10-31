namespace BookWise.Core.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}