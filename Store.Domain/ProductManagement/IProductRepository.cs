using System.Collections.Generic;

namespace Store.Domain.ProductManagement
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();
        void AddProduct(Product product);
        Product GetProductById(int id);
    }
}