using AutoMapper;
using Store.ConsoleServiceClient.CustomerService;
using Store.ConsoleServiceClient.OrderService;
using Store.ConsoleServiceClient.ProductService;
using Store.ConsoleServiceClient.Service;

namespace Store.ConsoleServiceClient
{
    public class Program
    {
        static void Main()
        {
             ConfigureAutoMapper();

            //Do staff

            var customerServiceClent = new CustomerServiceClient();
            var productServiceClient = new ProductServiceClient();
            var orderServiceClinet = new OrderServiceClient();
            var serviceClient = new ServiceClient();

            var consoleInterface = new ConsoleInterface(orderServiceClinet, productServiceClient, customerServiceClent, serviceClient);
            consoleInterface.Run();
        }

        private static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(GeneralAutoMapperProfile)));
        }
    }
}
