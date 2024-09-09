using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class OrderDetailRepository : EntityRepositoryBase<OrderDetail, NorthwndContext>, IOrderDetailRepository
    {
        public List<FeaturedProductDto> GetFeaturedProducts(params string[] includeList)
        {
            var allProducts = GetListQueryable(includeList: includeList)
                             .Select(x => new JoinedProductDataDto()
                    {
                        ProductName = x.Product.ProductName,
                        UnitPrice = x.Product.UnitPrice,
                        Quantity = x.Quantity,
                        PhotoPath = x.Product.ProductPhotos.FirstOrDefault().PhotoPath,
                        Discount = x.Discount
                    }).ToList();

            var result = allProducts
                 .GroupBy(x => new { x.ProductName, x.UnitPrice, x.PhotoPath, x.Discount })
                 .Select(x => new FeaturedProductDto
                 {
                     Quantity = x.Sum(x => x.Quantity.Value),
                     PhotoPath = x.Key.PhotoPath,
                     ProductName = x.Key.ProductName,
                     UnitPrice = x.Key.UnitPrice,
                     UnitPriceForSale = x.Key.Discount.Value != 0 ? ((decimal)(1-(x.Key.Discount.Value)) * x.Key.UnitPrice.Value) : x.Key.UnitPrice
                 })
                 .OrderByDescending(x=>x.Quantity)
                 .Take(8)
                 .ToList();
                  

            return result;

            
        }

        public List<FeaturedProductDto> GetUrun(params string[] includeList)
        {
            var allProducts = GetListQueryable(includeList: includeList)
                             .Select(x => new JoinedProductDataDto()
                             { 
                                 UnitsInStock = x.Product.UnitsInStock,
                                 Description = x.Product.Description,
                                 SupplierID = x.Product.SupplierID,
                                 Fotografbir = x.Product.Fotografbir,
                                 CategoryID = x.Product.CategoryID,
                                 ProductID = x.Product.ProductId,
                                 ProductName = x.Product.ProductName,
                                 UnitPrice = x.Product.UnitPrice,
                                 Quantity = x.Quantity,
                                 PhotoPath = x.Product.ProductPhotos.FirstOrDefault().PhotoPath,
                                 Discount = x.Discount
                             }).ToList();

            var result = allProducts
                 .GroupBy(x => new { x.ProductID,x.CategoryID,x.UnitsInStock,x.Description,x.SupplierID,x.ProductName, x.Fotografbir, x.UnitPrice, x.PhotoPath, x.Discount })
                 .Select(x => new FeaturedProductDto
                 {
                     UnitsInStock = x.Key.UnitsInStock,
                     Description = x.Key.Description,
                     SupplierID = x.Key.SupplierID,
                     Fotografbir = x.Key.Fotografbir,
                     CategoryID = x.Key.CategoryID,
                     ProductID = x.Key.ProductID,
                     Quantity = x.Sum(x => x.Quantity.Value),
                     PhotoPath = x.Key.PhotoPath,
                     ProductName = x.Key.ProductName,
                     UnitPrice = x.Key.UnitPrice,
                     UnitPriceForSale = x.Key.Discount.Value != 0 ? ((decimal)(1 - (x.Key.Discount.Value)) * x.Key.UnitPrice.Value) : x.Key.UnitPrice
                 })
                 .OrderByDescending(x => x.Quantity)  
                 .ToList();

            return result;


        }
    }
}
