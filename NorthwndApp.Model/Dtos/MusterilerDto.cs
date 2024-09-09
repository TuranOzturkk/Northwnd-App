using Infrastructure.Model;
using NorthwndApp.Model.Entities;
using System.Collections;
using System.Collections.Generic;

namespace NorthwndApp.Model.Dtos
{
    public class MusterilerDto:IDto
    {
        public List<Musteriler> Musteriler { get; set; }
        public string Mail { get; set; }
        public int MusteriID { get; set; }

        public bool? IsActive { get; set; }
    }
}
