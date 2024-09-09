using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class HomeIndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
