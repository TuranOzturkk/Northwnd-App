using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Concrete
{
    public class EmployeeBs : BusinessBase<Employee>, IEmployeeBs
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBs(IEmployeeRepository employeeRepository)
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee LogIn(string userName, string password, params string[] includeList)
        {
            return _employeeRepository.LogIn(userName,password, includeList);
        }


    }
}
