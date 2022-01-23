using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IQueryable<OrderDetail> GetOrderDetailByOrder(Expression<Func<OrderDetail, bool>> expression);
    }
}
