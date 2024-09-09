using Infrastructure.Model;
using System.Collections.Generic;

namespace NorthwndApp.Model.Entities
{

    public class Product:IEntity
    {
        
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductPhotos = new HashSet<ProductPhoto>();
           
        }
        public string Description { get; set; }
        public string QuantityPerUnit {get; set;}
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        //public int? CategoryId { get; set; }
       
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Fotografbir { get; set; }
        public string Fotografiki { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        



    }
}
