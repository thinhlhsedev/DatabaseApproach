using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Product> GetAllProducts()
        {
            IQueryable<Product> list = _productRepository.GetAll(p => p.Status == "1");
            return list;
        }
    }
}
