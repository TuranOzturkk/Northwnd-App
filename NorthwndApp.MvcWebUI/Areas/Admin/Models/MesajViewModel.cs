using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class MesajViewModel
    {
        public List<Iletisim> iletisimlist { get; set; }
        public Iletisim Iletisim { get; set; }
        public Employee Employee { get; set; }
    }
}
