namespace NorthwndApp.MvcWebUI.Models
{
    public class ProductSaveViewModel
    {
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; } 
    }
}
