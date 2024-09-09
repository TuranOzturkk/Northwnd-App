using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface ISupplierBs: IBusinessBase<Supplier>
    {
        Supplier GetById(int SupplierId, params string[] includeList);
        Supplier LogIn(string KullaniciAdi, string KullaniciParola, params string[] includeList);
    }
}
