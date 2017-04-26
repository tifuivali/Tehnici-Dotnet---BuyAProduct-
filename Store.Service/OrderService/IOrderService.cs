﻿using System.Collections.Generic;
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
        int CreateCart(Customer customer);

        [OperationContract]
        string DeleteOrder(int id);
    }
}
