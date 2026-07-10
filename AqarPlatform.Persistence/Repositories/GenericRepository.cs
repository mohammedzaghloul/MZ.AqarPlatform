using AqarPlatform.Domain.Common;
using AqarPlatform.Domain.Interfaces;
using AqarPlatform.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbSet= dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
                return await    _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
         return await   _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {

             await _dbSet.SingleAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
