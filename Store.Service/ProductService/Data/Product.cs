using System.Collections.Generic;
using System.Runtime.Serialization;
using Store.Service.OrderService.Data;

namespace Store.Service.ProductService.Data
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Specification { get; set; }
        [DataMember]
        public virtual string ImageUrl { get; set; }
        [DataMember]
        public virtual double Price { get; set; }
        [DataMember]
        public virtual ProductCategory Category { get; set; }
        [DataMember]
        public virtual ICollection<Order> Orders { get; set; }
    }
}