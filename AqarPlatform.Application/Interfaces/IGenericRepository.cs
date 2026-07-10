using AqarPlatform.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

       public Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
