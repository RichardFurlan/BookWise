using BookWise.Core.Entities;

namespace BookWise.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetDetailsById(int id);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<bool> ExistAsync(int id);
    void UpdateAsync(User user);
    Task AddAsync(User user);
}