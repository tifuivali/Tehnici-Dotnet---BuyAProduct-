using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.ProductCategoryManagement;
using Store.Domain.ProductManagement;
using Product = Store.Service.ProductService.Data.Product;
using ProductCategory = Store.Service.ProductService.Data.ProductCategory;

namespace Store.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = productRepository.GetAllProducts().Select(Mapper.Map<Product>);
            return products;
        }

        public string AddProduct(Product product)
        {
            var domainProduct = Mapper.Map<Domain.ProductManagement.Product>(product);
            productRepository.AddProduct(domainProduct);
            return "Product created!";
        }

        public Product GetProductById(int id)
        {
            var domainProduct = productRepository.GetProductById(id);
            return Mapper.Map<Product>(domainProduct);
        }

        public string AddProductCategory(ProductCategory productCategory)
        {
            var domainProductCategory = Mapper.Map<Domain.ProductCategoryManagement.ProductCategory>(productCategory);
            productCategoryRepository.AddProductCategory(domainProductCategory);
            return "Product category created!";
        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return productCategoryRepository.GetAllProductCategories().Select(Mapper.Map<ProductCategory>);
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            var domainProductCategory = productCategoryRepository.GetProductCategoryById(id);
            return Mapper.Map<ProductCategory>(domainProductCategory);
        }
    }
}
