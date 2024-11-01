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
    public async Task<User?> GetWithDetailsByIdAsync(int id)
    {
        return await _genericRepository
                                .GetByIdQueryable(id)
                                .Include(u => u.Loans)
                                .ThenInclude(u => u.Book)
                                .Include(u => u.Ratings)
                                .ThenInclude(u => u.Book)
                                .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _genericRepository.GetByConditionWithId(u => u.Email == email && u.Password == passwordHash);
    }
    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _genericRepository.ExistsByIdAsync(id);
    }

    public void Update(User user)
    {
        _genericRepository.Update(user);
    }

    public async Task AddAsync(User user)
    {
        await _genericRepository.AddAsync(user);
    }
}