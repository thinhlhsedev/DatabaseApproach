using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailController(
             OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
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
            return Ok(data);
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
