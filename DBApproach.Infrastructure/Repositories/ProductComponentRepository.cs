using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ProductComponentRepository : Repository<ProductComponent>, IProductComponentRepository
    {
        public ProductComponentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
