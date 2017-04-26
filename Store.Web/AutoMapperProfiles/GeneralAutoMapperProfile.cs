using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.Models;

namespace Store.Web.AutoMapperProfiles
{
    public class GeneralAutoMapperProfile: Profile
    {
        public GeneralAutoMapperProfile()
        {
            CreateMap<UserLoginAccountViewModel, CustomerAccount>().ReverseMap();
            CreateMap<UserAccountViewModel, Customer>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<ProductViewModel, ProductService.Product>().ReverseMap();
            CreateMap<Customer, OrderService.Customer>().ReverseMap();
        }
    }
}