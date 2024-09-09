using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Concrete
{
    public class OrderBs : BusinessBase<Order>, IOrderBs
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBs(IOrderRepository orderRepository)
            :base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteById(int OrderID)
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int OrderID, params string[] includelist)
        {
            return _orderRepository.Get(x => x.OrderID == OrderID, includelist);
        }

        public List<Order> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            throw new System.NotImplementedException();
        }
    }
}
