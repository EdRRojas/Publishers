using Microsoft.EntityFrameworkCore;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;
using System.ComponentModel;
using System.Security.Cryptography;

namespace publishers.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
        where TId : IEquatable<TId>
    {
        public readonly PubsContext context;
        public readonly DbSet<TEntity> DbEntity;

        protected BaseRepository(PubsContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }
        public virtual void create(TEntity entity)
        {
            DbEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any(filter);
        }

        public virtual List<TEntity> FinnAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntity.ToList();
        }

        public virtual TEntity GetEntity(TId id)
        {
            return DbEntity.Find(id);
        }

        public virtual void remove(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }

        public virtual void update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }

    }
}
