using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Abstract
{
    public interface ICustomerBs : IBusinessBase<Customer>
    {
        
      List<Customer> GetByPriceRange(decimal min, decimal max, params string[] includeList);

        Customer GetById(int CustomerID, params string[] includeList);
        void DeleteById(int CustomerID);
    }
}
