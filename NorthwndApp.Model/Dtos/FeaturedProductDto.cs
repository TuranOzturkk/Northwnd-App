using Infrastructure.Model;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Model.Dtos
{
    public class FeaturedProductDto:IDto
    {
        public Product ProductTo { get; set; }
        public int ProductID { get; set; }
        public string Fotografbir { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string PhotoPath { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceForSale { get; set; }
        public int CommentCount { get; set; }
        public int CommentPoint { get; set; }
        public int Quantity { get; set; }
        public int? SupplierID { get; set; }

        public string Description { get; set; }
        public short UnitsInStock { get; set; }



       
    }
}
