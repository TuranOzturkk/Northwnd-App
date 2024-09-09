using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwndApp.Model.Entities
{
    public class ProductYorum:IEntity
    {
        [Key]
        public int YorumID { get; set; }
        public int ProductyorumID { get; set; }
        public int MusteriyorumID { get; set; }
        public string Yorum { get; set; }
        public string Mail { get;set; }
       
        public int? Puan { get; set; }

        public string PuanDeneme {get; set; }
    }

}

