using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
