using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Exceptions;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;
using System.Linq.Expressions;

namespace publishers.Infrastructure.Repositories
{
    public class PublishersRepository : BaseRepository<Publishers, string>, IpublishersRepository
    {
        private readonly PubsContext context;
        private readonly ILogger<PublishersRepository> logger;
        public PublishersRepository(PubsContext context, ILogger<PublishersRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override void create(Publishers publishers)
        {
            try
            {
                if (context.publishers.Any(pub => pub.pub_name == publishers.pub_name))
                    throw new PublishersException("Este publisher ya esta registrado.");
                this.context.publishers.Add(publishers);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al intentar crear el publisher.", ex.ToString());
            }
        }
        public override List<Publishers> GetEntities()
        {
            return base.GetEntities().Where(pub => !pub.deleted).ToList();
        }

        public override void update(Publishers publishers)
        {
            try
            {
                var PublishersToUpdate = this.GetEntity(publishers.pub_id);

                PublishersToUpdate.pub_name = publishers.pub_name;
                PublishersToUpdate.city = publishers.city;
                PublishersToUpdate.state = publishers.state;
                PublishersToUpdate.country = publishers.country;
                PublishersToUpdate.userMod = publishers.userMod;
                PublishersToUpdate.modifyDate = publishers.modifyDate;

                this.context.publishers.Update(PublishersToUpdate);
                this.context.SaveChanges();
            }
            catch(Exception ex) {
                this.logger.LogError("Error al intentar actualizar los datos.", ex.ToString());
            }
        }
        public override void remove(Publishers publishers)
        {
            try
            {
                var PublishersToRemove = this.GetEntity(publishers.pub_id);
                PublishersToRemove.deleted = true;
                PublishersToRemove.userDeleted = publishers.userDeleted;
                PublishersToRemove.deleteTime = publishers.deleteTime;

                this.context.publishers.Update(PublishersToRemove);
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al intentar eliminar este publisher.");
            }

        }

        public publishersModel GetPubByName(String pub_name)
        {
            publishersModel Publishers = new publishersModel();
            try
            {
                if (!base.Exists(pub => pub.pub_name == pub_name))
                {
                    throw (new Exception("Este publisher no esta registrado."));
                }
                Publishers = (from publi in this.context.publishers
                              where publi.pub_name == pub_name
                              select new publishersModel()
                              {
                                  pub_name = publi.pub_name,
                                  city = publi.city,
                                  state = publi.state,
                                  country = publi.country
                              }).FirstOrDefault();
                return Publishers;
            }
            catch (Exception ex)
            {
                this.logger.LogError("", ex.ToString());
            }
            return Publishers;
        }
       

        public List<publishersModel> GetPubByCity(string city)
        {
            List<publishersModel> Publishers = new List<publishersModel>();
            try
            {
                Publishers = (from publi in this.context.publishers
                              where publi.city == city
                              select new publishersModel
                              {
                                  pub_name = publi.city,
                                  city = publi.city,
                                  state = publi.state,
                                  country = publi.country
                              }).ToList();

                return Publishers;
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al buscar el publisher", ex.ToString());
            }
            return Publishers;
        }

        public List<publishersModel> GetPubByState(string state)
        {
            List<publishersModel> Publishers = new List<publishersModel>();
            try
            {
                Publishers = (from publi in this.context.publishers
                              where publi.state == state
                              select new  publishersModel
                              {
                                  pub_name = publi.state,
                                  city = publi.city,
                                  state = publi.state,
                                  country = publi.country
                              }).ToList();
                return Publishers;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al buscar el publisher. ", ex.ToString());
            }
            return Publishers;
        }

        public List<publishersModel> GetPubByCountry(string country)
        {
            List<publishersModel> Publishers = new List<publishersModel>();
            try
            {
                Publishers = (from publi in this.context.publishers
                              where publi.country == country
                              select new publishersModel
                              {
                                  pub_name = publi.state,
                                  city = publi.city,
                                  state = publi.state,
                                  country = publi.country
                              }).ToList();
                return Publishers;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al buscar el publisher. ", ex.ToString());
            }
            return Publishers;
        }
    }
}
