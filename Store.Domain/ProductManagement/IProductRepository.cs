using System.Collections.Generic;

namespace Store.Domain.ProductManagement
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        Product GetProductById(int id);
    }
}