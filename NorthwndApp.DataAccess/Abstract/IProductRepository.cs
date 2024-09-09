using Infrastructure.DataAccess;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface IProductRepository:IEntityRepository<Product>
    {
        List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList);
        public List<Product> Urunler(params string[] includeList);
    }
}
