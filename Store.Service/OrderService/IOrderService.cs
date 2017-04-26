using System.Collections.Generic;
using System.ServiceModel;
using Store.Service.CustomerService.Data;
using Store.Service.OrderService.Data;

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
        int UpdateUserCart(Cart cart);

        [OperationContract]
        string DeleteOrder(int id);
    }
}
