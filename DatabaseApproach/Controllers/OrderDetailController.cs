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
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(
             OrderDetailService orderDetailService,
             IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        // GET: getOrderDetailOfs/ord/1
        [HttpGet]
        [Route("getOrderDetailsOf/ord/{orderId}")]
        public ActionResult<IQueryable<Order>> GetAllOrders(string orderId)
        {
            var data = _orderDetailService.GetOrderDetailsByOrder(orderId);
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<OrderResponse>>(data);
            return Ok(list);
        }

        // GET: getOrderDetail/1
        [HttpGet]
        [Route("getOrderDetail/{orderDetailId}")]
        public ActionResult<OrderDetailResponse> GetOrderDetailById(string orderDetailId)
        {
            var data = _orderDetailService.GetOrderDetailById(orderDetailId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var orderDetail = _mapper.Map<OrderDetailResponse>(data);
            return Ok(orderDetail);
        }

        // PUT: UpdateOrderDetail/1
        [HttpPut]
        [Route("updateOrderDetail/{orderDetailId}")]
        public ActionResult<OrderDetailResponse> UpdateOrderDetail(string orderDetailId, [FromBody] OrderDetailRequest newOrderDetail)
        {
            var data = _orderDetailService.UpdateOrderDetail(orderDetailId, _mapper.Map<OrderDetail>(newOrderDetail));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var orderDetail = _mapper.Map<OrderDetailResponse>(data);
            return Ok(orderDetail);
        }

        // PUT: DelOrderDetail/1
        [HttpPut]
        [Route("delOrderDetail/{orderDetailId}")]
        public ActionResult DelOrderDetail(string orderDetailId)
        {
            var data = _orderDetailService.DelOrderDetail(orderDetailId);
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
