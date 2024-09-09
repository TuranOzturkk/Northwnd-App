using Infrastructure.Model;
using System.Collections.Generic;

namespace NorthwndApp.Model.Entities
{

    public class Sepet:IEntity
    {
       
        public int SepetID { get; set; }
        public int? UrunID { get; set; }
        public int? MusteriID { get; set; }
        public int? SepAdet { get; set; }



        public decimal Fiyat { get; set; }
        public string Adi { get; set; }
        public string Fotograf { get; set; }
    }
}
