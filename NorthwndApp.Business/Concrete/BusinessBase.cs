using Infrastructure.DataAccess;
using Infrastructure.Model;
using NorthwndApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NorthwndApp.Business.Concrete
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _repo;

        public BusinessBase(IEntityRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public int Delete(TEntity entity)
        {
            return _repo.Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }
      
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetList(filter, includeList);
        }

        public TEntity Insert(TEntity entity)
        {
            return _repo.Insert(entity);
        }

       

        public TEntity Update(TEntity entity)
        {
            return _repo.Update(entity);
        }
    }
}
