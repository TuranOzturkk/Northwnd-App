using Infrastructure.DataAccess;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface ISupplierRepository : IEntityRepository<Supplier>
    {
        Supplier LogIn(string KullaniciAdi, string KullaniciParola, params string[] includeList);
    }
}
