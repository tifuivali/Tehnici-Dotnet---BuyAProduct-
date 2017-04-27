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

        public int AddProduct(Product product)
        {
            var domainProduct = Mapper.Map<Domain.ProductManagement.Product>(product);
            var createdProductId = productRepository.AddProduct(domainProduct);
            return createdProductId;
        }

        public int UpdateProduct(Product product)
        {
            var domainProduct = Mapper.Map<Domain.ProductManagement.Product>(product);
            var updatedProductId = productRepository.UpdateProduct(domainProduct);
            return updatedProductId;
        }

        public Product GetProductById(int id)
        {
            var domainProduct = productRepository.GetProductById(id);
            return Mapper.Map<Product>(domainProduct);
        }

        public int AddProductCategory(ProductCategory productCategory)
        {
            var domainProductCategory = Mapper.Map<Domain.ProductCategoryManagement.ProductCategory>(productCategory);
            var productCategoryId = productCategoryRepository.AddProductCategory(domainProductCategory);
            return productCategoryId;
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

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            return productRepository.GetProductsByName(name).Select(Mapper.Map<Product>).ToList();
        }

        public IEnumerable<string> GetProductSugestions(string productName)
        {
            return productRepository.GetPrducttNameForGivenName(productName).ToList();
        }
    }
}

