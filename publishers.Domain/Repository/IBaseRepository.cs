
namespace publishers.Domain.Repository
{
    public interface IBaseRepository <TEntity, TId> where TEntity : class where TId : IEquatable<TId>
    {
        TEntity GetEntityById(TId id);
        List<TEntity> GetEntities();
        List<TEntity> FindAll(Func<TEntity, bool> filter);
        bool Exists(Func<TEntity, bool> filter);

        void Create (TEntity entity);
        void Update (TEntity entity);
        void Remove (TEntity entity);
    }
}
