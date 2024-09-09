using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.Business.Abstract
{
    public interface IOrderDetailBs : IBusinessBase<OrderDetail>
    {
        public List<FeaturedProductDto> GetFeaturedProducts(params string[] includeList);
        public List<FeaturedProductDto> GetUrun(params string[] includeList);
    }
}
