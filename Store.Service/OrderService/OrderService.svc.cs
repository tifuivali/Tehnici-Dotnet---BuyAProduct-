using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.CartManagement;
using Store.Domain.OrderManagement;
using Store.Service.CustomerService.Data;
using Order = Store.Service.OrderService.Data.Order;

namespace Store.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartRepository cartRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
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

        public int CreateCart(Customer customer)
        {
            var cartId = cartRepository.CreateCart(Mapper.Map<Domain.CustomerManagement.Customer>(customer));
            return cartId;
        }

        public string DeleteOrder(int id)
        {
            orderRepository.DeleteOrderById(id);
            return "Order deleted!";
        }
    }
}
