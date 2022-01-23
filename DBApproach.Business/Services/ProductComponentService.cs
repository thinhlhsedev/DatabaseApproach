using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class ProductComponentService
    {
        private readonly IProductComponentRepository _productComponentRepository;

        public ProductComponentService(
            IProductComponentRepository productComponentRepository)
        {
            _productComponentRepository = productComponentRepository;
        }

        public IQueryable<Role> CreateProCompo()
        {
            //IQueryable<Role> list = _productComponentRepository
            return null;
        }
    }
}
