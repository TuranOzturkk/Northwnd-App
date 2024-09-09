using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Models
{
    public class ProductAddViewModelSatici
    {
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public List<Supplier> Supplist { get; set; }

      
    }
}
