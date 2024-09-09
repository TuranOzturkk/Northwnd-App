using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.Business.Concrete
{

    public class ProductYorumBs : BusinessBase<ProductYorum>, IProductYorumBs
    {
        private readonly IProductYorumRepository _productyorumRepository;
        public ProductYorumBs(IProductYorumRepository productyorumRepository)
            : base(productyorumRepository)
        {
            _productyorumRepository = productyorumRepository;
        }
        public ProductYorum GetById(int YorumID, params string[] includelist)
        {
            return _productyorumRepository.Get(x => x.YorumID == YorumID, includelist);
        }
        public void DeleteById(int YorumID)
        {
            Delete(GetById(YorumID));
        }
    }
}