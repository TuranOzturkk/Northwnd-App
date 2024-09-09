using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwndApp.Model.Entities
{
    public class Customer:IEntity
    {
        //public string CustomerName;
        [Key]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string CustomerID { get; set; }

    }
}
