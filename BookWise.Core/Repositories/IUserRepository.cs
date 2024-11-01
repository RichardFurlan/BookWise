using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetWithDetailsByIdAsync(int id);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<bool> ExistsByIdAsync(int id);
    void Update(User user);
    Task AddAsync(User user);
}