using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Domain.Exceptions;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;
using static System.Formats.Asn1.AsnWriter;

namespace publishers.Infrastructure.Repositories
{
    public class StoreRepository : BaseRepository<Store, string>, IStoreRepository
    {
        private const string message = "Ha ocurrido un error. \n\n";
        private new readonly PubsContext context;
        private readonly ILogger<StoreRepository> logger;

        public StoreRepository(PubsContext context, ILogger<StoreRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Create(Store store)
        {
            try
            {
                this.context.stores.Add(store);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError(message, ex.ToString());
            }
        }


        public override List<Store> GetEntities()
        {
            return base.GetEntities().Where(stores => !stores.deleted).ToList();
        }

        public List<Store> GetStoresByState(string state)
        {
            return base.GetEntities().Where(stores => stores.state == state).ToList();
        }

        public Store GetStoreById(string stor_id)
        {
            return (Store)base.GetEntities().Where(store => store.stor_id == stor_id);
        }

        public override void Update(Store store)
        {
            try
            {
                var store_to_update = this.GetEntity(store.stor_id);

                store_to_update.stor_name = store.stor_name;
                store_to_update.stor_address = store.stor_address;
                store_to_update.city = store.city;
                store_to_update.state = store.state;
                store_to_update.zip = store.zip;

                this.context.stores.Update(store_to_update);
            } catch(Exception ex)
            {
                this.logger.LogError(message, ex.ToString());
            }

        }

        public override void Remove(Store store)
        {
            try
            {
                var store_to_delete = this.GetEntity(store.stor_id);

                store_to_delete.deleted = true;
                store_to_delete.userDeleted = store.userDeleted;
                store_to_delete.deleteTime = store.deleteTime;

                this.context.stores.Update(store_to_delete);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError(message, ex.ToString());
            }
        }
    }
}
