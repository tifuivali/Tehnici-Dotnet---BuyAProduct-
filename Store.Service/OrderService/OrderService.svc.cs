using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.CartManagement;
using Store.Domain.OrderManagement;
using Store.Domain.ProductManagement;
using Store.Service.ProductService.Data;
using Cart = Store.Service.OrderService.Data.Cart;
using Order = Store.Service.OrderService.Data.Order;

namespace Store.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
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

        public int CreateCart(string email)
        {
            var cartId = cartRepository.CreateCart(email);
            return cartId;
        }

        public Cart GetUserCart(string email)
        {
            return Mapper.Map<Cart>(cartRepository.GetUserCart(email));
        }

        public int UpdateUserCart(Cart cart)
        {
            return cartRepository.UpdateUserCart(Mapper.Map<Domain.CartManagement.Cart>(cart));
        }

        public string DeleteOrder(int id)
        {
            orderRepository.DeleteOrderById(id);
            return "Order deleted!";
        }

        public int AddProductToCart(int productId, string userEmail)
        {
            cartRepository.AddProductToCart(productId, userEmail);
            return 1;
        }
    }
}
