﻿using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApproach.Controllers.ModelControllers
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
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var data = await _productService.GetAllProducts();
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<List<ProductResponse>>(data);
            return Ok(list);
        }

        // GET: getProduct/1
        [HttpGet]
        [Route("getProduct/{productId}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(string productId)
        {
            var data = await _productService.GetProductById(productId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var product = _mapper.Map<ProductResponse>(data);
            return Ok(product);
        }

        // POST: AddProduct/[product]
        [HttpPost]
        [Route("addProduct")]
        public async Task<ActionResult> AddAccount([FromBody] ProductRequest productRequest)
        {
            var data = await _productService.AddProduct(_mapper.Map<Product>(productRequest));
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            return Ok("Add successfully");
        }

        // PUT: UpdateProduct/1
        [HttpPut]
        [Route("updateProduct/{productId}")]
        public async Task<ActionResult> UpdateProduct(string productId, [FromBody] ProductRequest productRequest)
        {
            var data = await _productService.UpdateProduct(productId, _mapper.Map<Product>(productRequest));
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Update Successfully");
            }
            return BadRequest(data);
        }

        // PUT: DelProduct/1
        [HttpPut]
        [Route("delProduct/{productId}")]
        public async Task<ActionResult> DelProduct(string productId)
        {
            var data = await _productService.DelProduct(productId);
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Update Successfully");
            }
            return BadRequest(data);
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
