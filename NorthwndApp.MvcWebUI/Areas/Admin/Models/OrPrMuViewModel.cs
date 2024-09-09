using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class OrPrMuViewModel
    {
        
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        
        public List<Musteriler> Musteriler { get; set; }
    }
}
