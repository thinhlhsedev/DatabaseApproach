using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetOrderByAccount(Expression<Func<Order, bool>> expression);
    }
}
