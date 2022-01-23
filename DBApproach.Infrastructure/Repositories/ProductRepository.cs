using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;

namespace DBApproach.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
