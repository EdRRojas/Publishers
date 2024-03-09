using publishers.Infrastructure.Context;
using publishers.Domain.Entities;
using publishers.Infrastructure.Interface;
using publishers.Infrastructure.Core;
using Microsoft.Extensions.Logging;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Repository
{
    public class DiscountsRepository : BaseRepository<Discounts, string>, IDiscountsRepository
    {
        private readonly PubsContext context;
        private readonly ILogger<DiscountsRepository> logger;
        private string? discounttype;

        public DiscountsRepository(PubsContext context, ILogger<DiscountsRepository> logger): base(context) 
        {
            this.context = context;
            this.logger = logger;
        }
         public override List<Discounts> GetEntities()
         {
            return base.GetEntities();
         }
         
        public override void create(Discounts discounts)
        {
            try
            {
                if (context.discounts.Any(di => di.discounttype == discounts.discounttype));
                    throw new Exception("Este descuento fue añadido.");

                this.context.discounts.Add(discounts);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrio un error al añadir un descuendo.", ex.ToString());
            }
        }
        public override void update(Discounts discounts)
        {
            try
            {
                var DiscountsToUpdate = this.GetEntity(discounts.discounttype);

                DiscountsToUpdate.discounttype = discounts.discounttype;
                DiscountsToUpdate.stor_id = discounts.stor_id;
                DiscountsToUpdate.lowqty = discounts.lowqty;
                DiscountsToUpdate.highqty = discounts.highqty;
                DiscountsToUpdate.discount = discounts.discount;
                DiscountsToUpdate.modifyDate = discounts.modifyDate;
                DiscountsToUpdate.userMod = discounts.userMod;

                this.context.discounts.Update(DiscountsToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ha ocurrido un error al intentar actualizar descuentos.", ex.ToString);
            }
            
        }
        public override void remove(Discounts discounts)
        {
            try
            {
                var DiscountsToRemove = this.GetEntity(discounts.discounttype);

                DiscountsToRemove.deteled = 0;
                DiscountsToRemove.userDeleted = discounts.userDeleted;
                DiscountsToRemove.deteleTime = discounts.deteleTime;

                this.context.discounts.Update(DiscountsToRemove);
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Ha ocurrido un error al intentar remover descuentos", ex.ToString);
            }

        }

        public DiscountsModel GetdiscounttypeByName(string name)
        {
            DiscountsModel discounts = new DiscountsModel();
            try
            {
                discounts   = (from di in this.context.discounts
                             join stor in this.context.stores on di.stor_id equals stor.stor_id
                             where di.discounttype == "Customer Discount"
                             select new DiscountsModel()
                             {
                                 discounttype = di.discounttype,
                                 stor_id = stor.stor_id,
                             }).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                this.logger.LogError("No se encontraron ningún descuento con este nombre.", ex.ToString);
            }
            return discounts;
        }

        public List<DiscountsModel> Getstor_idByID(int id)
        {
            List<DiscountsModel> discounts = new List<DiscountsModel>();
            try
            {
              discounts = (from di in this.context.discounts
                          join stor in this.context.stores on di.stor_id equals stor.stor_id
                          where di.stor_id == "8042"
                           select new DiscountsModel()
                          {
                              discounttype = di.discounttype,
                              stor_id = stor.stor_id,

                          }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("No se encontraron ningun descuento con este ID.", ex.ToString);
            }

            return discounts;
        }

        public List<DiscountsModel> GetdiscountByDiscounts(decimal discount)
        {
            List<DiscountsModel> discounts = new List<DiscountsModel>();
            try
            {
                discounts = (from di in this.context.discounts
                             join stor in this.context.stores on di.stor_id equals stor.stor_id
                             where di.discount > 0
                             select new DiscountsModel()
                             {
                                 discounttype = di.discounttype,
                                 stor_id = stor.stor_id,
                                 discount = Convert.ToDecimal(di.discount)


                             }).ToList();
            }

            catch (Exception ex)
            {
                this.logger.LogError("No se encontraron ningun descuento con este descuento.", ex.ToString);

            }
            return discounts;

        }

       
    }
}

