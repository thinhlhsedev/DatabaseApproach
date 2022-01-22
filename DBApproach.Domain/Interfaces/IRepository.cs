using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(string id);
        void Update(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        T GetById(Expression<Func<T, bool>> expression);
    }
}
