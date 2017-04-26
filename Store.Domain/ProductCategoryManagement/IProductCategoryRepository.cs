using System.Collections.Generic;

namespace Store.Domain.ProductCategoryManagement
{
    public interface IProductCategoryRepository
    {
        void AddProductCategory(ProductCategory productCategory);
        IList<ProductCategory> GetAllProductCategories();
        ProductCategory GetProductCategoryById(int id);
    }
}