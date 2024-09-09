using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class EmployeeIletisimViewModel
    {
        public List<Iletisim> IletisimListesi { get; set; }
        public Employee employee { get; set; }
    }
}
