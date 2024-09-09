using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<Order> Orderlist { get; set; }


    }
}
