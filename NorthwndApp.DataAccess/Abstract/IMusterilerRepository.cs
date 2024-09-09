 using Infrastructure.DataAccess;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface IMusterilerRepository : IEntityRepository<Musteriler>
    {
        Musteriler LogIn(string KullaniciAdi, string Parola, params string[] includeList);
    }
}
