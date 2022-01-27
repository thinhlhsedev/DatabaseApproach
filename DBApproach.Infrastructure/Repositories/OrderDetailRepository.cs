using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
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
    }
}
