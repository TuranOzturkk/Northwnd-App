using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface ISepetBs : IBusinessBase<Sepet>
    {
        Sepet GetById(int SepetID, params string[] includeList);
    }
}
