using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(
             OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: getOrdersOf/acc/1
        [HttpGet]
        [Route("getOrdersOf/acc/{accountId}")]
        public ActionResult<IQueryable<Order>> GetAllOrders(string accountId)
        {
            var data = _orderService.GetAllOrders(accountId);
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
