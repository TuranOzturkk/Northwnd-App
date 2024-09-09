using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Concrete
{
    public class SupplierBs : BusinessBase<Supplier>, ISupplierBs
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierBs(ISupplierRepository supplierRepository)
            :base(supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void DeleteById(int SupplierId)
        {
            Delete(GetById(SupplierId));

        }
        public Supplier GetById(int SupplierId, params string[] includeList)
        {
            return _supplierRepository.Get(x => x.SupplierId == SupplierId, includeList);
        }
        public Supplier LogIn(string KullaniciAdi, string KullaniciParola, params string[] includeList)
        {
            return _supplierRepository.LogIn(KullaniciAdi, KullaniciParola, includeList);
        }

    }
}
