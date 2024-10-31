using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookWiseDbContext _context;
    private readonly GenericRepository<User> _genericRepository;
    public UserRepository(GenericRepository<User> genericRepository, BookWiseDbContext context)
    {
        _genericRepository = genericRepository;
        _context = context;
    }
    public async Task<User?> GetDetailsById(int id)
    {
        return await _context.Users
                                .Include(u => u.Loans)
                                .ThenInclude(u => u.Book)
                                .Include(u => u.Ratings)
                                .ThenInclude(u => u.Book)
                                .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _genericRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _context
            .Users
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _genericRepository.ExistsAsync(id);
    }

    public void UpdateAsync(User user)
    {
        _genericRepository.UpdateAsync(user);
    }

    public async Task AddAsync(User user)
    {
        await _genericRepository.AddAsync(user);
    }
}