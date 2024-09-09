using Infrastructure.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwndApp.Model.Entities
{
    public class Supplier:IEntity
    {
        
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string ApprovingCode { get; set; }
        public string Mail { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciParola { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
