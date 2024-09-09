namespace NorthwndApp.Model.Dtos
{
    public class JoinedProductDataDto
    {
        public string ProductName { get; set; }
        public string Fotografbir { get; set; }
        public decimal? UnitPrice { get; set; }
        public float? Discount { get; set; }
        public string PhotoPath { get; set; }
        public int? Quantity { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
    }
}
