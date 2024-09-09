using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
       
        public int Delete(TEntity entity)
        {
            //using (TContext ctx = new TContext())
            //{
            //    EntityEntry<TEntity> inserted = ctx.Entry(entity);

            //    inserted.State = EntityState.Deleted;
            //    return ctx.SaveChanges();
            //}

            using (TContext ctx = new TContext())
            {
                ctx.Set<TEntity>().Remove(entity);
                return ctx.SaveChanges();
            }
        }
        

public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                

                return dbSet.SingleOrDefault(filter);

            }
        }
       


        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }

                return filter != null ? dbSet.Where(filter).ToList() : dbSet.ToList();

            }
        }

        public IQueryable<TEntity> GetListQueryable(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            TContext ctx = new TContext();

            IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

            if (includeList.Length > 0)
            {
                foreach (var item in includeList)
                {
                    dbSet = dbSet.Include(item);
                }
            }

            return filter != null ? dbSet.Where(filter) : dbSet;


        }

        public TEntity Insert(TEntity entity)
        {
            //using (TContext ctx = new TContext())
            //{
            //    EntityEntry<TEntity> inserted = ctx.Entry(entity);

            //    inserted.State = EntityState.Added;
            //    ctx.SaveChanges();

            //    return inserted.Entity;
            //}

            using (TContext ctx = new TContext())
            {
                EntityEntry<TEntity> inserted = ctx.Set<TEntity>().Add(entity);
                ctx.SaveChanges();

                return inserted.Entity;
            }
        }

       

        public TEntity Update(TEntity entity)
        {
            //using (TContext ctx = new TContext())
            //{
            //    EntityEntry<TEntity> updated = ctx.Entry(entity);

            //    updated.State = EntityState.Modified;
            //    ctx.SaveChanges();

            //    return updated.Entity;
            //}

            using (TContext ctx = new TContext())
            {
                EntityEntry<TEntity> updated = ctx.Set<TEntity>().Update(entity);
                ctx.SaveChanges();

                return updated.Entity;
            }
        }
    }
}
