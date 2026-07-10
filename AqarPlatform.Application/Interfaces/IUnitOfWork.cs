using AqarPlatform.Domain.Common;
using AqarPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : BaseEntity;
    }
}
