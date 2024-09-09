using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.Business.Abstract
{
    public interface IProductBs: IBusinessBase<Product>
    {
        List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList);
        
        Product GetById(int productId, params string[] includeList);
        void DeleteById(int productId);
        public List<Product> Urunler(params string[] includeList);
    }
}
