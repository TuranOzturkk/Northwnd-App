using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Concrete
{
    public class OrderDetailBs : BusinessBase<OrderDetail>, IOrderDetailBs
    {
        private readonly IOrderDetailRepository _odRepository;
        public OrderDetailBs(IOrderDetailRepository odRepository)
            : base(odRepository)
        {
            _odRepository = odRepository;
        }

        public List<FeaturedProductDto> GetFeaturedProducts(params string[] includeList)
        {
            return _odRepository.GetFeaturedProducts(includeList: includeList);
        }

        public List<FeaturedProductDto> GetUrun(params string[] includeList)
        {
            return _odRepository.GetUrun(includeList: includeList);
        }
    }
}
