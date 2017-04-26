using System.Collections.Generic;
using System.ServiceModel;
using Store.Service.ProductService.Data;

namespace Store.Service.ProductService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts();

        [OperationContract]
        string AddProduct(Product product);

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        string AddProductCategory(ProductCategory productCategory);

        [OperationContract]
        IEnumerable<ProductCategory> GetAllProductCategories();

        [OperationContract]
        ProductCategory GetProductCategoryById(int id);
    }
}
