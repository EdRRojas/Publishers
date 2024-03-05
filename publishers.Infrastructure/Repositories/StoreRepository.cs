using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


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

        public override  void  Create(Store store)
        {
            Validate(store);

            if (context.stores.Any(st => st.stor_id == store.stor_id))
                throw new Exception("Este id ya esta registrado.");

            this.context.stores.Add(store);
            this.context.SaveChanges();
        }


        public override List<Store> GetEntities()
        {
            return base.GetEntities().Where(stores => stores?.deleted == null).ToList();
        }

        public List<Store> GetStoresByState(string state)
        {
            return base.GetEntities().Where(stores => stores.state == state).ToList();
        }

        public Store GetStoreById(string stor_id)
        {
            return base.GetEntities().FirstOrDefault(store => (store.stor_id == stor_id && store.deleted == null));
        }

        public override void Update(Store store)
        {
            try
            {
                Validate(store);
                var store_to_update = this.GetStoreById(store.stor_id);

                if (store_to_update != null)
                {
                    store_to_update.stor_name = store.stor_name;
                    store_to_update.stor_address = store.stor_address;
                    store_to_update.city = store.city;
                    store_to_update.state = store.state;
                    store_to_update.zip = store.zip;

                    this.context.stores.Update(store_to_update);
                    this.context.SaveChanges();
                }
                else
                {
                    this.logger.LogError("Store with ID {0} not found.", store.stor_id);
                }

            } catch(Exception ex)
            {
                this.logger.LogError(message, ex.ToString());
            }

        }

        public override void Remove(Store store)
        {
            try
            {
                Validate(store);
                var store_to_delete = this.GetEntity(store.stor_id);

                store_to_delete.deleted = true;
                store_to_delete.userDelete = store.userDelete;
                store_to_delete.deleteTime = store.deleteTime;

                this.context.stores.Update(store_to_delete);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError(message, ex.ToString());
            }
        }

        private void Validate(Store store)
        {
            var validationContext = new ValidationContext(store, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(store, validationContext, validationResults, validateAllProperties: true))
            {
                var validationErrors = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
                throw new ValidationException(validationErrors);
            }
        }
    }
}
