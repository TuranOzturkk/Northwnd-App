using Infrastructure.DataAccess;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Employee LogIn(string userName,string password, params string[] includeList);
    }
}
