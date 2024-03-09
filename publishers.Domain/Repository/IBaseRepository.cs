
using publishers.Domain.Entities;

namespace publishers.Domain.Repository
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class
        where TId : IEquatable<TId>
    {
        TEntity GetEntity(TId id);
        List<TEntity> GetEntities();
        List<TEntity> FindAll(Func<TEntity, bool> filter);
        bool Exists(Func<TEntity, bool> filter);
        void create(TEntity entity);
        void update(TEntity entity);

        void remove(TEntity entity);
    }
}
