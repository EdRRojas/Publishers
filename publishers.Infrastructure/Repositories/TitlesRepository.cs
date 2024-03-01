

using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Domain.Exceptions;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Repositories
{
    public class TitlesRepository : BaseRepository<Titles, string>, ITitlesRepository
    {
        private readonly PubsContext context;
        private readonly ILogger<TitlesRepository> logger;

        public TitlesRepository(PubsContext context, ILogger<TitlesRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }        
        public override List<Titles> GetEntities()
        {
            return base.GetEntities().Where(ti => !ti.deleted).ToList();
        }
        public override void Create(Titles titles)
        {
            try {
                if (context.titles.Any(ti => ti.title == titles.title))
                    throw new TitlesException("Este libro ya esta registrado.");

            this.context.titles.Add(titles);
            this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrio un error al intentar añadir el libro", ex.ToString());
            }
        }
        public override void Update(Titles titles)
        {
            try { 
            var TitlesToUpdate = this.GetEntity(titles.title_id);

            TitlesToUpdate.title = titles.title;
            TitlesToUpdate.type = titles.type;
            TitlesToUpdate.price = titles.price;
            TitlesToUpdate.advance = titles.advance;
            TitlesToUpdate.royalty = titles.royalty;
            TitlesToUpdate.ytd_sales = titles.ytd_sales;
            TitlesToUpdate.notes = titles.notes;
            TitlesToUpdate.userMod = titles.userMod;
            TitlesToUpdate.modifyDate = titles.modifyDate;

            this.context.titles.Update(TitlesToUpdate);
            this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Ocurrio un error al intentar actualizar los datos de este libro", ex.ToString());
            }
        }
        public override void Remove(Titles titles)
        {
            try { 
            var TitleToRemove = this.GetEntity(titles.title_id);

            TitleToRemove.deleted = true;
            TitleToRemove.userDeleted = titles.userDeleted;
            TitleToRemove.deleteTime = titles.deleteTime;

            this.context.titles.Update(TitleToRemove);
            this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Ocurrio un error al intentar eliminar este libro", ex.ToString());
            }
        }

        public TitlesModel GetTitleByName(string title)
        {
            TitlesModel Title = new TitlesModel();
            try
            {
                if(!base.Exists(ti => ti.title == title))                
                    throw (new Exception("Este libro no esta registrado"));
                
                Title = (from tit in this.context.titles
                          join pub in this.context.publishers on tit.pub_id equals pub.pub_id
                          where tit.title == title
                          select new TitlesModel()
                          {
                              title = tit.title,
                              type = tit.type,
                              pub_name = pub.pub_name,
                              price = tit.price,
                              advance = tit.advance,
                              royalty = tit.royalty,
                              ytd_sales = tit.ytd_sales,
                              notes = tit.notes
                          }).FirstOrDefault();

                return Title;
            }
            catch(Exception ex)
            {
                this.logger.LogError("", ex.ToString());
            }
            return Title;
        }

        public List<TitlesModel> GetTitlesByType(string types)
        {
            List<TitlesModel> Title = new List<TitlesModel>();
            try
            {
                Title = (from tit in this.context.titles
                         join pub in this.context.publishers on tit.pub_id equals pub.pub_id
                         where tit.type == types
                         select new TitlesModel
                         {
                             title = tit.title,
                             type = tit.type,
                             pub_name = pub.pub_name,
                             price = tit.price,
                             advance = tit.advance,
                             royalty = tit.royalty,
                             ytd_sales = tit.ytd_sales,
                             notes = tit.notes
                         }).ToList();    
                return Title;
            }
            catch(Exception ex)
            {
                this.logger.LogError("Ocurrio un error al buscar los libros", ex.ToString);
            }
            return Title;
        }

        public List<TitlesModel> GetTitlesByPub(string pub_id)
        {
            List<TitlesModel> Title = new List<TitlesModel>();
            try
            {
                Title = (from tit in this.context.titles
                         join pub in this.context.publishers on tit.pub_id equals pub.pub_id
                         where pub.pub_id == pub_id
                         select new TitlesModel
                         {
                             title = tit.title,
                             type = tit.type,
                             pub_name = pub.pub_name,
                             price = tit.price,
                             advance = tit.advance,
                             royalty = tit.royalty,
                             ytd_sales = tit.ytd_sales,
                             notes = tit.notes                             
                         }).ToList();
                return Title;
            }
            catch(Exception ex)
            {
                this.logger.LogError("Ocurrio un error intentando encontrar los libros", ex.ToString);
            }
            return Title;
        }

        public List<TitlesModel> GetTitlesByUnderPrice(decimal price)
        {
            List<TitlesModel> Title = new List<TitlesModel>();
            try
            {
                Title = (from tit in this.context.titles
                         join pub in this.context.publishers on tit.pub_id equals pub.pub_id
                         where tit.price <= price
                         select new TitlesModel
                         {
                             title = tit.title,
                             type = tit.type,
                             pub_name = pub.pub_name,
                             price = tit.price,
                             advance = tit.advance,
                             royalty = tit.royalty,
                             ytd_sales = tit.ytd_sales,
                             notes = tit.notes
                         }).ToList();
                return Title;
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error bucando los precios de los libros", ex.ToString);
            }
            return Title;
        }

        public List<TitlesModel> GetTitlesByOnPrice(decimal price)
        {
            List<TitlesModel> Title = new List<TitlesModel>();
            try
            {
                Title = (from tit in this.context.titles
                         join pub in this.context.publishers on tit.pub_id equals pub.pub_id
                         where tit.price >= price
                         select new TitlesModel
                         {
                             title = tit.title,
                             type = tit.type,
                             pub_name = pub.pub_name,
                             price = tit.price,
                             advance = tit.advance,
                             royalty = tit.royalty,
                             ytd_sales = tit.ytd_sales,
                             notes = tit.notes
                         }).ToList();
                return Title;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error bucando los precios de los libros", ex.ToString);
            }
            return Title;
        }

        public TitlesModel GetTitleSalesByID(int ytd_sales)
        {
            TitlesModel Title = new TitlesModel();
            try
            {
                Title = (from tit in this.context.titles                         
                         where tit.ytd_sales == ytd_sales
                         select new TitlesModel
                         {
                             price = tit.ytd_sales
                         }
                         ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error bucando los precios de los libros", ex.ToString);
            }
            return Title;
        }
    }
}
