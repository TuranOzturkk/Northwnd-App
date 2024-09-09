using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.Business.Concrete
{
    public class IletisimBs : BusinessBase<Iletisim>, IIletisimBs
    {
        private readonly IIletisimRepository _ıletisimRepository;

        public IletisimBs(IIletisimRepository ıletisimRepository)
            : base(ıletisimRepository)
        {
            _ıletisimRepository = ıletisimRepository;
        }

        public Iletisim GetById(int IletisimID, params string[] includeList)
        {
            return _ıletisimRepository.Get(x => x.IletisimID == IletisimID, includeList);
        }


    }
}
