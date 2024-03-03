using Microsoft.EntityFrameworkCore;
using publishers.Domain.Repository;
using publishers.Infrastructure.Contex;
using System;

namespace publishers.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class where TId : IEquatable<TId>
    {
        public readonly PubsContex contex;
        public readonly DbSet<TEntity> Dbentity;

        protected BaseRepository(PubsContex contex)
        {
            this.contex = contex;
            Dbentity = contex.Set<TEntity>();
        }
        public virtual void Create(TEntity entity)
        {
            Dbentity.Add(entity);
            contex.SaveChanges();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
           return Dbentity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return Dbentity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return Dbentity.ToList();
        }

        public virtual TEntity GetEntityById(TId id)
        {
            return Dbentity.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
           Dbentity.Update(entity);
           contex.SaveChanges();
        }
        public virtual void Remove(TEntity entity)
        {
            Dbentity.Update(entity);
            contex.SaveChanges();
        }
    }
}
