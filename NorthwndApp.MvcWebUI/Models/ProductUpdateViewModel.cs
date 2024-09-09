using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product ProductToUpdate { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        
    }
}
