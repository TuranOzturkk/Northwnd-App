using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class MusterilerAddDto
    {
        public List <Musteriler> Musteriler { get; set; }
        public int MusteriID { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaSahibi { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Adres { get; set; }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KartHesapNo { get; set; }
        public string KartSahibi { get; set; }
        public string KartKullanimSuresi { get; set; }
        public string KartCvc { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }



  


    }
}
