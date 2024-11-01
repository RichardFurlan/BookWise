using System.Linq.Expressions;
using BookWise.Core.Entities;
using BookWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly BookWiseDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(BookWiseDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<T?> GetByConditionWithId(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.SingleOrDefaultAsync(expression);
    }
    
    public IQueryable<T> GetByIdQueryable(int id)
    {
        return _dbSet.Where(e => e.Id == id);
    }
    public  IQueryable<T> GetAll()
    {
        return _dbSet;
    }
    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return;
        entity.SetAsDeleted();
        Update(entity);
    }

    public void Update(T entity)
    {
        entity.MarkAsUpdated();
        _dbSet.Update(entity);
    }
}