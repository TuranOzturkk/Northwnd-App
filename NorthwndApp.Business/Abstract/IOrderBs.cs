using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Abstract
{
    public interface IOrderBs : IBusinessBase<Order>
    {
        List<Order> GetByPriceRange(decimal min, decimal max, params string[] includeList);
        Order GetById(int OrderID, params string[] includeList);
        void DeleteById(int OrderID);
    }
}

