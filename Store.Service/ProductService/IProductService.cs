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
        int AddProduct(Product product);

        [OperationContract]
        int UpdateProduct(Product product);

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        int AddProductCategory(ProductCategory productCategory);

        [OperationContract]
        IEnumerable<ProductCategory> GetAllProductCategories();

        [OperationContract]
        IEnumerable<Product> SearchProductsByName(string name);

        [OperationContract]
        IEnumerable<string> GetProductSugestions(string productName);

        [OperationContract]
        ProductCategory GetProductCategoryById(int id);
    }
}
