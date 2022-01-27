using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Order>> GetOrderByAccount(string accountId)
        {
            return await _orderRepository.GetAll(p => p.AccountId == accountId);
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            return await _orderRepository.GetById(p => p.OrderId == orderId);
        }

        public async Task<string> AddOrder(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<string> UpdateOrder(string orderId, Order newOrder)
        {

            var data = await _orderRepository.FindById(p => p.OrderId == orderId);
            if (data != null)
            {
                newOrder.OrderId = data.OrderId;
                await _orderRepository.Update(newOrder);                
            }
            return null;
        }

        public async Task<string> DelOrder(string orderId)
        {
            var data = await _orderRepository.GetById(p => p.OrderId == orderId);
            if (data != null)
            {
                data.Status = "Inactive";
                await _orderRepository.Update(data);                
            }
            return null;
        }

    }
}
