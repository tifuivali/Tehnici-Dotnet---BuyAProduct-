using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Database.Models
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get;set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
