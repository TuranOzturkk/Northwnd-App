using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class ProductRepository:EntityRepositoryBase<Product,NorthwndContext>, IProductRepository
    {
        public List<Product> GetByPriceRange(decimal min,decimal max,params string[] includeList)
        {
            return GetList(x => x.UnitPrice > min && x.UnitPrice < max, includeList);
        }

        public List<Product> Urunler(params string[] includeList)
        {
            var allProducts = GetListQueryable(includeList: includeList)
                             .Select(x => new Product()
                             {
                                 UnitsInStock = x.UnitsInStock,
                                 Description = x.Description,
                                 SupplierID = x.SupplierID,
                                 Fotografbir = x.Fotografbir,
                                 CategoryID = x.CategoryID,
                                 ProductId = x.ProductId,
                                 ProductName = x.ProductName,
                                 UnitPrice = x.UnitPrice,
                                 QuantityPerUnit = x.QuantityPerUnit,
                                
                                 
                             }).ToList();

            var result = allProducts
                 .GroupBy(x => new { x.ProductId, x.CategoryID, x.UnitsInStock, x.Description, x.SupplierID, x.ProductName, x.Fotografbir, x.UnitPrice,x.QuantityPerUnit})
                 .Select(x => new Product
                 {
                     UnitsInStock = x.Key.UnitsInStock,
                     Description = x.Key.Description,
                     SupplierID = x.Key.SupplierID,
                     Fotografbir = x.Key.Fotografbir,
                     CategoryID = x.Key.CategoryID,
                     ProductId = x.Key.ProductId,
                     QuantityPerUnit = x.Key.QuantityPerUnit,
                    
                     ProductName = x.Key.ProductName,
                     UnitPrice = x.Key.UnitPrice,
                     
                 })
                 .OrderByDescending(x => x.QuantityPerUnit)
                 .ToList();

            return result;


        }
    }
}
