using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IQueryable<Order> GetAllOrders(string accountId)
        {
            IQueryable<Order> list = _orderRepository.GetOrderByAccount(p => p.AccountId == accountId).Distinct();
            return list;
        }
    }
}
