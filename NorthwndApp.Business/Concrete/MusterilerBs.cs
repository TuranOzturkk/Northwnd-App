using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using System;
using System.Collections.Generic;
using NorthwndApp.Business.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructure.Model;
using System.Linq.Expressions;

namespace NorthwndApp.Business.Concrete
{
    public class MusterilerBs : BusinessBase<Musteriler>, IMusterilerBs
    {
        private readonly IMusterilerRepository _musterilerRepository;

        public MusterilerBs(IMusterilerRepository musterilerRepository)
            : base(musterilerRepository)
        {
            _musterilerRepository = musterilerRepository;

        }

        public Musteriler LogIn(string KullaniciAdi, string Parola, params string[] includeList)
        {
            return _musterilerRepository.LogIn(KullaniciAdi,Parola, includeList);
        }
        public void DeleteById(int MusteriID)
        {
            Delete(GetById(MusteriID));
        }

        public Musteriler GetById(int MusteriID, params string[] includeList)
        {
            return _musterilerRepository.Get(x => x.MusteriID == MusteriID, includeList);
        }
       


        public List<Musteriler> GetByPriceRange(decimal min, decimal max, params string[] includeList)
        {
            throw new NotImplementedException();
        }
       
    }
}




    
    
        
   
   
