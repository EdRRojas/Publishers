using publishers.Infrastructure.Context;
using publishers.Domain.Entities;
using publishers.Infrastructure.Interface;

namespace publishers.Infrastructure.Repository
{
    public class DiscountsRepository : IDicountsRepository 
    {
        private readonly PubsContext context;

        public void create(Discounts discounts)
        {
            try
            {
                this.context.discounts.Add(discounts);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Discounts GetDiscountsByID(int stor_id)
        {
            return this.context.discounts.Find(stor_id);
        }

        public void remove(Discounts discounts)
        {
            try
            {
                var DiscountsToDelete = this.GetDiscountsByID(discounts.stor_id);

                DiscountsToDelete.deleted = true;
                DiscountsToDelete.userDeleted = discounts.userDeleted;
                DiscountsToDelete.deletedDate = discounts.deletedDate;


                this.context.discounts.Update(DiscountsToDelete);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(Discounts discounts)
        {
            try
            {
                var DiscountsToUpdate = this.GetDiscountsByID(discounts.stor_id);

                DiscountsToUpdate.discounttype = discounts.discounttype;
                DiscountsToUpdate.stor_id = discounts.stor_id;
                DiscountsToUpdate.lowqty = discounts.lowqty;
                DiscountsToUpdate.highqty = discounts.highqty;
                DiscountsToUpdate.discount = discounts.discount;
                DiscountsToUpdate.userMod = discounts.userMod;
                DiscountsToUpdate.modifyDate = discounts.modifyDate;

                this.context.discounts.Update(DiscountsToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

