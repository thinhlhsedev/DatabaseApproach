using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(
            IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IQueryable<OrderDetail> GetOrderDetailsByOrder(string orderId)
        {
            IQueryable<OrderDetail> list = _orderDetailRepository
                .GetOrderDetailByOrder(p => p.OrderId == orderId).Distinct();
            return list;
        }
    }
}
