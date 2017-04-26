using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Database;

namespace Store.Domain.ProductCategoryManagement
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly StoreContext storeContext;
        public ProductCategoryRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            var productCategoryDto = Mapper.Map<Database.Models.ProductCategory>(productCategory);
            storeContext.ProductCategories.Add(productCategoryDto);
            storeContext.SaveChanges();
        }

        public IList<ProductCategory> GetAllProductCategories()
        {
            return storeContext.ProductCategories.ProjectToList<ProductCategory>();
        }

        public ProductCategory GetProductCategoryById(int id)
        {
           var productCategory = storeContext.ProductCategories.SingleOrDefault(x => x.Id == id);
            return Mapper.Map<ProductCategory>(productCategory);
        }
    }
}
