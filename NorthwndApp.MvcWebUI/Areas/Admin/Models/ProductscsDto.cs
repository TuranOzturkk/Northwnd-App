using NorthwndApp.Model.Entities;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class ProductscsDto
    {
        public int CompanyName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }

    }
}
