using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(
             ProductService productService,
             IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
            var list = _mapper.Map<IEnumerable<ProductResponse>>(data);
            return Ok(data);
        }

        // GET: getProduct/1
        [HttpGet]
        [Route("getProduct/{productId}")]
        public ActionResult<ProductResponse> GetProductById(string productId)
        {
            var data = _productService.GetProductById(productId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var product = _mapper.Map<ProductResponse>(data);
            return Ok(product);
        }

        // PUT: UpdateProduct/1
        [HttpPut]
        [Route("updateProduct/{productId}")]
        public ActionResult<ProductResponse> UpdateProduct(string productId, [FromBody] ProductRequest newProduct)
        {
            var data = _productService.UpdateProduct(productId, _mapper.Map<Product>(newProduct));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var product = _mapper.Map<ProductResponse>(data);
            return Ok(product);
        }

        // PUT: DelProduct/1
        [HttpPut]
        [Route("delProduct/{productId}")]
        public ActionResult DelProduct(string productId)
        {
            var data = _productService.DelProduct(productId);
            if (!data)
            {
                return BadRequest("Delete Failed");
            }
            return Ok("Delete Successfully");
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
