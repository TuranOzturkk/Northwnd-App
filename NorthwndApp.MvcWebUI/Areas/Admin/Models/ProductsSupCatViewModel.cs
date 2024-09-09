using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class ProductsSupCatViewModel
    {
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
       

        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
       
        public Product ProductUpdate { get; set; }





    }
    

}
