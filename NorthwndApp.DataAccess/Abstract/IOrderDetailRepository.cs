using Infrastructure.DataAccess;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface IOrderDetailRepository : IEntityRepository<OrderDetail>
    {
        public List<FeaturedProductDto> GetFeaturedProducts(params string[] includeList);
        public List<FeaturedProductDto> GetUrun(params string[] includeList);
    }
}
