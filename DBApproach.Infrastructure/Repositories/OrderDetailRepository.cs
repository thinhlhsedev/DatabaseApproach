using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<OrderDetail> GetOrderDetailByOrder(Expression<Func<OrderDetail, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
