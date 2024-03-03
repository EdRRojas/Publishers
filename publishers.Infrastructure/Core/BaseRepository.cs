using Microsoft.EntityFrameworkCore;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;
using System.Security.Cryptography;

namespace publishers.Infrastructure.Core
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
        where TId : IEquatable<TId>
    {
        public readonly PubsContext context;
        public readonly DbSet<TEntity> DbEntity;

        protected BaseRepository(PubsContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }
        public bool create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FinnAll(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(TId id)
        {
            throw new NotImplementedException();
        }

        public bool update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
