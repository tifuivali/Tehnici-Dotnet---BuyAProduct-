using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.OrderManagement;
using Order = Store.Service.OrderService.Data.Order;

namespace Store.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders().Select(Mapper.Map<Order>);
        }

        public string AddOrder(Order order)
        {
            var domainOrder = Mapper.Map<Domain.OrderManagement.Order>(order);
            orderRepository.AddOrder(domainOrder);
            return "Order created!";
        }

        public string DeleteOrder(int id)
        {
            orderRepository.DeleteOrderById(id);
            return "Order deleted!";
        }
    }
}
