using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwndApp.Business.Abstract
{
    public interface IBusinessBase<TEntity>
        where TEntity:class,IEntity,new()
    {
        
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);
       
    }
}
