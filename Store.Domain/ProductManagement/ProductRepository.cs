using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Database;
using Store.Database.Models;

namespace Store.Domain.ProductManagement
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IList<Product> GetAllProducts()
        {
            return storeContext.Products.Select(Mapper.Map<Product>).ToList();
        }

        public Product GetProductById(int id)
        {
            var product = storeContext.Products.SingleOrDefault(x => x.Id == id);
            return Mapper.Map<Product>(product);
        }

        public void AddProduct(Product product)
        {
            var productDto = Mapper.Map<Database.Models.Product>(product);
            storeContext.Products.Add(productDto);
            storeContext.SaveChanges();
        }

    }
}
