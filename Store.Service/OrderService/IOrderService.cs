using System.Collections.Generic;
using System.ServiceModel;
using Store.Service.OrderService.Data;
using Store.Service.ProductService.Data;

namespace Store.Service.OrderService
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<Order> GetAllOrders();

        [OperationContract]
        string AddOrder(Order order);

        [OperationContract]
        int CreateCart(string email);

        [OperationContract]
        Cart GetUserCart(string email);

        [OperationContract]
        int AddProductToCart(int productId, string userEmail);

        [OperationContract]
        int UpdateUserCart(Cart cart);

        [OperationContract]
        string DeleteOrder(int id);
    }
}
