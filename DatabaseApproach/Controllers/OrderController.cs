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
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(
             OrderService orderService,
             IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: getOrdersOf/acc/1
        [HttpGet]
        [Route("getOrdersOf/acc/{accountId}")]
        public ActionResult<IQueryable<OrderResponse>> GetAllOrders(string accountId)
        {
            var data = _orderService.GetOrderByAccount(accountId);
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<OrderResponse>>(data);
            return Ok(data);
        }

        // GET: getOrder/1
        [HttpGet]
        [Route("getOrder/{orderId}")]
        public ActionResult<OrderResponse> GetOrderById(string orderId)
        {
            var data = _orderService.GetOrderById(orderId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var order = _mapper.Map<OrderResponse>(data);
            return Ok(order);
        }

        // PUT: UpdateOrder/1
        [HttpPut]
        [Route("updateOrder/{orderId}")]
        public ActionResult<OrderResponse> UpdateOrder(string orderId, [FromBody] OrderRequest newOrder)
        {
            var data = _orderService.UpdateOrder(orderId, _mapper.Map<Order>(newOrder));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var order = _mapper.Map<OrderResponse>(data);
            return Ok(order);
        }

        // PUT: DelOrder/1
        [HttpPut]
        [Route("delOrder/{orderId}")]
        public ActionResult DelrOder(string orderId)
        {
            var data = _orderService.DelOrder(orderId);
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
