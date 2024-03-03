using System.Security.Cryptography;

namespace publishers.Domain.Repository
{
    public interface IBaseRepository <TEntity, TId> where TEntity : class
        where TId : IEquatable<TId>
      
    {
           TEntity GetEntity(TId id);
        List<TEntity> GetEntities();
        List<TEntity> FinnAll(Func<TEntity, bool> filter);
        bool Exists(Func<TEntity, bool> filter);
        bool create(TEntity entity);
        bool update(TEntity entity);
    }

}

