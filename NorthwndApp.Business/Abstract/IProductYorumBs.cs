using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface IProductYorumBs : IBusinessBase<ProductYorum>
    {
        ProductYorum GetById(int YorumID, params string[] includeList);
        void DeleteById(int YorumID);
    }
}
