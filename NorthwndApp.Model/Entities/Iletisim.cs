using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace NorthwndApp.Model.Entities
{
    public class Iletisim : IEntity
    {
        [Key]
        public int  IletisimID { get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesa { get; set; }
        public bool? Active { get; set; }
       public string Adi { get; set; }
       public string Cevap { get; set; }

    }
}
