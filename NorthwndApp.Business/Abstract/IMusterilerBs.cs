using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Abstract
{
    public interface IMusterilerBs : IBusinessBase<Musteriler>
    {
        Musteriler LogIn(string KullaniciAdi, string Parola, params string[] includeList);

        List<Musteriler> GetByPriceRange(decimal min, decimal max, params string[] includeList);

        Musteriler GetById(int MusteriID, params string[] includeList);

       

    }
}
