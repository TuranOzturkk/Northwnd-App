using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwndApp.Model.Entities
{
    public class Musteriler:IEntity
    {
        
        [Key]
        
        public int MusteriID { get; set; }
        public string FirmaAdi { get;set; }
        public string FirmaSahibi { get; set; }
        public bool? IsActive { get; set; }
        public string ApprovingCode { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get;set;}
        public string KartHesapNo { get; set; }
        public string KartSahibi { get; set; }
        public string KartKullanimSuresi { get; set; }
        public string KartCvc { get; set; }

      

        public string Telefon { get; set; }
        public string Mail { get; set; }   
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Adres { get; set; }

        public string KullaniciAdi { get; set; }
      
        public string Parola { get; set; }
        public string ParolaSorgu { get; set; }

    }
    
}
