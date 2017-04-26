using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.OrderService;
using Store.Web.ProductService;

namespace Store.Web
{
    public static class Configuration
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(Configuration));
            });
        }

        public static IContainer ConfigureAutoFac()
        {
           var builder = new ContainerBuilder();
            //Register Components
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<CustomerServiceClient>();
            builder.RegisterType<ProductServiceClient>();
            builder.RegisterType<OrderServiceClient>();
            var container = builder.Build();
            return container;
        }
    }
}