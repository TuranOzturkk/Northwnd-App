using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwndApp.Business.Concrete
{
    public class ProductBs :BusinessBase<Product>, IProductBs
    {
        private readonly IProductRepository _productRepository;
        public ProductBs(IProductRepository productRepository)
            :base(productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteById(int productId)
        {
            Delete(GetById(productId));
        }
       

        public Product GetById(int productId, params string[] includeList)
        {
            return _productRepository.Get(x => x.ProductId == productId, includeList);
        }

        public List<Product> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            return _productRepository.GetByPriceRange(min, max, includeList);
        }

        public List<Product> Urunler(params string[] includeList)
        {
            return _productRepository.Urunler(includeList: includeList);
        }
    }
}
