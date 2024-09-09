using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface ICategoryBs : IBusinessBase<Category>
    {
        Category GetById(int categoryId, params string[] includeList);
    }
}
