using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        T GetById(Expression<Func<T, bool>> expression);
        T FindById(Expression<Func<T, bool>> expression);
    }
}
