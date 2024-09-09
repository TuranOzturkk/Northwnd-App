using Infrastructure.Model;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.Model.Dtos
{
    public class SepetDto : IDto
    {
        public List<Sepet> Sepet { get; set; }
        public List<Product> Product { get; set; }
        public int SepetID { get; set; }
        public int? UrunID { get; set; }
        public int? MusteriID { get; set; }
        public int? SepAdet { get; set; }

    }
}
