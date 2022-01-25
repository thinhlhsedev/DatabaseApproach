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
            var data = _orderDetailRepository
                .GetOrderDetailByOrder(p => p.OrderId == orderId).Distinct();
            return data;
        }

        public OrderDetail GetOrderDetailById(string orderDetailId)
        {
            var data = _orderDetailRepository.GetById(p => p.OrderDetailId == orderDetailId);
            return data;
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return false;
        }

        public OrderDetail UpdateOrderDetail(string orderDetailId, OrderDetail newOrderDetail)
        {

            var data = _orderDetailRepository.GetById(p => p.OrderDetailId == orderDetailId);
            if (data != null)
            {
                newOrderDetail.OrderDetailId = data.OrderDetailId;
                _orderDetailRepository.Update(newOrderDetail);
                return newOrderDetail;
            }
            return null;
        }

        public bool DelOrderDetail(string orderDetailId)
        {
            var data = _orderDetailRepository.GetById(p => p.OrderDetailId == orderDetailId);
            if (data != null)
            {
                //data. = "Inactive";
                _orderDetailRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
