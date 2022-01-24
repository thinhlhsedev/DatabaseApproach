using DBApproach.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Add(T entity)
        {
            DbSet.AddAsync(entity);
            _dbFactory.DbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            _dbFactory.DbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            _dbFactory.DbContext.SaveChangesAsync();
        }

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }
    }
}
