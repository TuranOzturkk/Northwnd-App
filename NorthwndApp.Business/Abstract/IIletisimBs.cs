using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface IIletisimBs:IBusinessBase<Iletisim>
    {

        Iletisim GetById(int IletisimID, params string[] includeList);
    }
}
