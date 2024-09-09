using Infrastructure.DataAccess.EntityFramework;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class MusterilerRepository : EntityRepositoryBase<Musteriler, NorthwndContext>, IMusterilerRepository
    {
        public Musteriler LogIn(string KullaniciAdi, string Parola, params string[] includeList)
        {
            
            return Get(x => x.KullaniciAdi == KullaniciAdi && x.Parola == Parola && x.IsActive.Value, includeList);
        }

        
    }
}
    