using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class EmployeeRepository : EntityRepositoryBase<Employee, NorthwndContext>, IEmployeeRepository
    {
        public Employee LogIn(string userName, string password, params string[] includeList)
        {
            return Get(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
        }
    }
}
