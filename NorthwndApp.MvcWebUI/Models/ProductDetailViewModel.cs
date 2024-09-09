using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class ProductDetailViewModel
    { 
        public Product ProductToList { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public List<SelectListItem> ProductPhotos { get; set; }



    }
}
