﻿using AutoMapper;
using Store.Database.Models;

namespace Store.Domain.ProductManagement
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<Database.Models.Product, Product>().ReverseMap().MaxDepth(3).PreserveReferences();
            CreateMap<Product, Database.Models.Product>();
            CreateMap<ProductCategory, ProductCategoryManagement.ProductCategory>()
                .ForMember(x => x.Products, opt => opt.Ignore());
            CreateMap<ProductCategoryManagement.ProductCategory, ProductCategory>();
            CreateMap<ProductCategoryManagement.ProductCategory, Product>();
            CreateMap<Order, OrderManagement.Order>().ReverseMap().MaxDepth(3).PreserveReferences()
                .ForMember(x => x.Customer, opt => opt.Ignore());
            CreateMap<OrderManagement.Order, Order>();
            CreateMap<Customer, CustomerManagement.Customer>().ReverseMap().MaxDepth(3).PreserveReferences();
            CreateMap<ProductReview, ProductReviewManagement.ProductReview>()
                .ReverseMap()
                .MaxDepth(3)
                .PreserveReferences();
        }
    }
}