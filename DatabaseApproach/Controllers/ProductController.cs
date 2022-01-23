using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(
             ProductService productService)
        {
            _productService = productService;
        }

        // GET: getProducts
        [HttpGet]
        [Route("getProducts")]
        public ActionResult<IQueryable<Product>> GetAllProducts()
        {
            var data = _productService.GetAllProducts();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
