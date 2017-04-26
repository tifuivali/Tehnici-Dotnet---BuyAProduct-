using AutoMapper;
using Store.ConsoleServiceClient.CustomerService;
using ProductCategory = Store.ConsoleServiceClient.ProductService.ProductCategory;

namespace Store.ConsoleServiceClient
{
    public class GeneralAutoMapperProfile : Profile
    {
        public GeneralAutoMapperProfile()
        {
            CreateMap<Customer, OrderService.Customer>().ReverseMap();
            CreateMap<Product, OrderService.Product>().ReverseMap();
            CreateMap<ProductCategory, OrderService.ProductCategory>().ReverseMap();
        }
    }
}
