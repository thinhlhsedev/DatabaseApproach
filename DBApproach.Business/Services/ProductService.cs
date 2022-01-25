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

        public Product GetProductById(string productId)
        {
            var data = _productRepository.GetById(p => p.ProductId == productId);
            return data;
        }

        public bool AddProduct(Product product)
        {
            return false;
        }

        public Product UpdateProduct(string productId, Product newProduct)
        {

            var data = _productRepository.GetById(p => p.ProductId == productId);
            if (data != null)
            {
                newProduct.ProductId = data.ProductId;
                _productRepository.Update(newProduct);
                return newProduct;
            }
            return null;
        }

        public bool DelProduct(string productId)
        {
            var data = _productRepository.GetById(p => p.ProductId == productId);
            if (data != null)
            {
                data.Status = "Inactive";
                _productRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
