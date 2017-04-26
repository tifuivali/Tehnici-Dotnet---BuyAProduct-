using System.Collections.Generic;
using Store.Database.Models;

namespace Store.Domain.ProductCategoryManagement
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
