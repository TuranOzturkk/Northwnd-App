using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Concrete
{
    public class CustomerBs : BusinessBase<Customer>, ICustomerBs
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBs(ICustomerRepository customerRepository) 
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void DeleteById(int CustomerID)
        {
            Delete(GetById(CustomerID));
        }

        public Customer GetById(string customerID, params string[] includelist)
        {
            return _customerRepository.Get(x => x.CustomerID == customerID, includelist);
        }

        public Customer GetById(int CustomerID, params string[] includeList)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            throw new System.NotImplementedException();
        }
    }
}



