  
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class ProductsAddDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
       
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }


    }


}
