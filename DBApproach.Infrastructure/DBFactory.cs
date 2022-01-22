using DatabaseApproach.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApproach.Infrastructure
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<TestDbContext> _instanceFunc;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<TestDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
