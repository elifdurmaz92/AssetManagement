using AssetManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Data.Repository
{
    public class EfRepoBase<TEntity, Tcontext> : IEntityRepository<TEntity>
           where TEntity : class, IEntity, new()
          where Tcontext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                var deger = context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                var deger = context.SaveChanges();
            }
        }

        public async Task<IEnumerable<TEntity>> ExecuteSqlQueryOrProcedure(string Query)
        {
            List<TEntity> list;
            using (var context = new Tcontext())
            {
                list = await context.Set<TEntity>().FromSqlRaw(Query).ToListAsync();
                return list;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
               return filter == null
                    ?  await context.Set<TEntity>().ToListAsync()
                    :  await context.Set<TEntity>().Where(filter).ToListAsync();
               
            }
        }
        //public async Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    List<TEntity> entities;
        //    using (var context = new Tcontext())
        //    {
        //        entities = await context.Set<TEntity>().ToListAsync();
        //    }
        //    return entities;
        //}

        public void SoftDelete(TEntity entity)
        {
            entity.GetType().GetProperty("IsActive").SetValue(entity, false);
            Update(entity);
        }

        public void Update(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                var deger = context.SaveChanges();
            }
        }
    }
}
