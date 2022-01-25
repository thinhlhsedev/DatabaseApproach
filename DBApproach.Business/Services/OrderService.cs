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

        public IQueryable<Order> GetOrderByAccount(string accountId)
        {
            var data = _orderRepository.GetOrderByAccount(p => p.AccountId == accountId).Distinct();
            return data;
        }

        public Order GetOrderById(string orderId)
        {
            var data = _orderRepository.GetById(p => p.OrderId == orderId);
            return data;
        }

        public bool AddOrder(Order order)
        {
            return false;
        }

        public Order UpdateOrder(string orderId, Order newOrder)
        {

            var data = _orderRepository.GetById(p => p.OrderId == orderId);
            if (data != null)
            {
                newOrder.OrderId = data.OrderId;
                _orderRepository.Update(newOrder);
                return newOrder;
            }
            return null;
        }

        public bool DelOrder(string orderId)
        {
            var data = _orderRepository.GetById(p => p.OrderId == orderId);
            if (data != null)
            {
                data.Status = "Inactive";
                _orderRepository.Update(data);
                return true;
            }
            return false;
        }

    }
}
