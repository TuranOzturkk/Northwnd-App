using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Abstract
{
    public interface IEmployeeBs : IBusinessBase<Employee>
    {
        Employee LogIn(string userName, string password, params string[] includeList);
    }
}
