using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Models
{
    
    public class MusterilerGet
    {
       
        public string Adi { get; set; }
       
        public string Soyadi { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public string Adres { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }

       
    }
   
}
