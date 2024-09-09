using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class SupplierRepository : EntityRepositoryBase<Supplier, NorthwndContext>, ISupplierRepository
    {

        public Supplier LogIn(string KullaniciAdi, string KullaniciParola, params string[] includeList)
        {
            return Get(x => x.KullaniciAdi == KullaniciAdi && x.KullaniciParola == KullaniciParola && x.IsActive.Value, includeList);
        }
    }
}
