using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interface
{
    public interface IDicountsRepository 
    {
        void create(Discounts discounts);
        Discounts GetDiscountsByID(string discounttype);
        void update(Discounts discounts);
        void remove(Discounts discounts);

    }
}
