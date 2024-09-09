using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class UrunProductYorumViewModel
    {
        public Product Product { get; set; }
        public Musteriler Musteriler { get; set; }
        public ProductYorum ProductYorum { get; set; }
        public Category Category { get; set; }
        public List<ProductYorum> ProductYorumlistesi { get; set; }
        public List<Musteriler> Musterilerlistesi { get; set; }
        public List<Product> Productlistesi { get; set; }


    }
}
