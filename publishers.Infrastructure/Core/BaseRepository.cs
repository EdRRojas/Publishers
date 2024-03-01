﻿using Microsoft.EntityFrameworkCore;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;


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
        public virtual void Create(TEntity entity)
        {
            DbEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
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

        public virtual void Remove(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }
    }
}    