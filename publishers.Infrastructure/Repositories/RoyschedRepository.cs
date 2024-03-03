using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Contex;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Exceptions;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;
using System;

namespace publishers.Infrastructure.Repositories
{
    public class RoyschedRepository : BaseRepository<roysched,string>, IRoyschedRepository
    {
        private readonly PubsContex contex;
        private readonly ILogger<RoyschedRepository> logger;
        public RoyschedRepository(PubsContex contex, ILogger<RoyschedRepository> logger) : base(contex)
        {
            this.contex = contex;
            this.logger = logger;
        }
        public override void Create(roysched entity)
        {
            try
            {
                
                var royschedToAdd = GetEntityById(entity.title_id);

                royschedToAdd.CreationDate = DateTime.Now;
                this.contex.roysched.Add(royschedToAdd);

                this.contex.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro creando el Roysched!", ex.ToString());
            }
        }

        public override void Remove(roysched entity)
        {
            try
            {
                if (entity == null)
                    throw new RoyschedExection("No puede ser nulo");

                var royschedToRomve = GetEntityById(entity.title_id);

                royschedToRomve.UserDeleted = entity.UserDeleted;
                royschedToRomve.Deleted = true;
                royschedToRomve.DeleteTime = DateTime.Now;

                contex.roysched.Update(royschedToRomve);
                contex.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro eliminando el Roysched!", ex.ToString());
            }
        }

        public override void Update(roysched entity)
        {
            try
            {
                var royschedToUpdate = GetEntityById(entity.title_id);

                royschedToUpdate.title_id = entity.title_id;
                royschedToUpdate.lorange = entity.lorange;
                royschedToUpdate.hirange = entity.hirange;
                royschedToUpdate.royalty = entity.royalty;

                royschedToUpdate.UserMod = entity.UserMod;
                royschedToUpdate.ModifyTime = DateTime.Now;

                contex.roysched.Update(royschedToUpdate);
                contex.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro actualizando el Roysched!", ex.ToString());
            }
        }

        public List<roysched> GetEntities()
        {
            return base.GetEntities().Where(ti => !ti.Deleted).ToList();
        }

         public List<RoyschedModel> GetRoyschedByTitleName(string title)
        {
            List<RoyschedModel> royscheds = new List<RoyschedModel>();
            try
            {
                royscheds = (from ro in this.contex.roysched
                             join ti in this.contex.titles on ro.title_id equals ti.title_id
                             where ti.title_id == title
                             select new RoyschedModel()
                             {
                                 title = ti.Title,
                                 type = ti.type,
                                 title_id = ti.title_id,
                                 price = ti.price,
                                 lorange = ro.lorange,
                                 hirange = ro.hirange,
                                 royalty = ro.royalty

                             }).ToList();

                


            }
            catch (Exception ex) 
            {
                
                this.logger.LogError("Error obteniendo los Roysched",ex.ToString());
            }
            return royscheds;
        }

        List<RoyschedModel> IRoyschedRepository.GetRoyschedByLorange(int lorange)
        {
            List<RoyschedModel> royscheds = new List<RoyschedModel>();

            try
            {
                if (!base.Exists(ro => ro.lorange == lorange))
                    throw new Exception("No se encontro el Low Range");

                royscheds = (from ro in this.contex.roysched
                             join ti in this.contex.titles on ro.title_id equals ti.title_id
                             where ro.lorange == lorange
                             select new RoyschedModel()
                             {
                                 title = ti.Title,
                                 type = ti.type,
                                 title_id = ti.title_id,
                                 price = ti.price,
                                 lorange = ro.lorange,
                                 hirange = ro.hirange,
                                 royalty = ro.royalty

                             }).ToList();




            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los Roysched", ex.ToString());
            }
            return royscheds;

        }

        List<RoyschedModel> IRoyschedRepository.GetRoyschedByHirange(int hirange)
        {
            List<RoyschedModel> royscheds = new List<RoyschedModel>();

            try
            {
                if (!base.Exists(ro => ro.hirange == hirange))
                    throw new Exception("No se encontro el High Range");

                royscheds = (from ro in this.contex.roysched
                             join ti in this.contex.titles on ro.title_id equals ti.title_id
                             where ro.hirange == hirange
                             select new RoyschedModel()
                             {
                                 title = ti.Title,
                                 type = ti.type,
                                 title_id = ti.title_id,
                                 price = ti.price,
                                 lorange = ro.lorange,
                                 hirange = ro.hirange,
                                 royalty = ro.royalty

                             }).ToList();




            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los Roysched", ex.ToString());
            }
            return royscheds;
        }

        List<RoyschedModel> IRoyschedRepository.GetRoyschedByRoyalty(int royalty)
        {
            List<RoyschedModel> royscheds = new List<RoyschedModel>();

            try
            {
                if (!base.Exists(ro => ro.royalty == royalty))
                    throw new Exception("No se encontro el Low Range");

                royscheds = (from ro in this.contex.roysched
                             join ti in this.contex.titles on ro.title_id equals ti.title_id
                             where ro.royalty == royalty
                             select new RoyschedModel()
                             {
                                 title = ti.Title,
                                 type = ti.type,
                                 title_id = ti.title_id,
                                 price = ti.price,
                                 lorange = ro.lorange,
                                 hirange = ro.hirange,
                                 royalty = ro.royalty

                             }).ToList();




            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los Roysched", ex.ToString());
            }
            return royscheds;
        }


    }
}
