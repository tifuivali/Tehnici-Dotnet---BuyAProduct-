using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Store.Service.ProductService.Data
{
    [DataContract]
    public class ProductCategory
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }
    }
}