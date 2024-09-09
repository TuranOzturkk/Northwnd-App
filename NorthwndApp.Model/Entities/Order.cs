using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwndApp.Model.Entities
{

    public class Order:IEntity
    {

        public Order()
        {

            //Products = new HashSet<Product>();
            //Musteriler = new HashSet<Musteriler>();


        }

        //SIPARIS
        [Key]
        public int OrderID { get; set; }
        //MUSTERI
        public int?  MusteriSiparisID { get; set; }
        //URUN
        public int? ProductSiparisID { get; set; }

        //SIPARIS TARIHI
        public DateTime? OrderDate { get; set; }

        //SIPARIS KARGO VERME TARIHI
        public DateTime? ShippedDate { get; set; }

        //FIYAT
        public decimal Freight { get; set; }
        

        public int? SuppliersID { get; set; }
        public int? MusterilerID { get; set; }
        public int? ProductsID { get; set; }
        public string MusAdi { get; set; }
        public string MusSoyadi { get; set; }
        public string MusTelefon { get; set; }
        public string UrunAdi { get; set; }
        public int? Adet { get; set; }
        public bool? SipOnay { get; set; }
        public bool? SipKargoverildi { get; set; }
        public bool? SipTeslimEdildi { get; set; }
    



        
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int? ShipVia { get; set; }





        //public virtual ICollection<Product> Products { get; set; }
       //public virtual ICollection<Musteriler>Musteriler { get; set; }


    }
}
