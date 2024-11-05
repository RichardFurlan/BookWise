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

    public async Task<T?> GetSingleByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.SingleOrDefaultAsync(expression);
    }
    
    public  IQueryable<T> GetAll()
    {
        return _dbSet.Where(entity => !entity.IsDeleted);
    }
    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return GetAll().Where(expression);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.MarkAsUpdated();
        _dbSet.Update(entity);
    }
}