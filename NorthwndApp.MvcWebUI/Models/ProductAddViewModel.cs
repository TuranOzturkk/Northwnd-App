using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
