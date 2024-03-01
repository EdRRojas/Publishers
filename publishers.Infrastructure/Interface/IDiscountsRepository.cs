using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interface
{
    public interface IDicountsRepository 
    {
        void create(Discounts discounts);
        Discounts GetDiscountsByID(int stor_id);
        void update(Discounts discounts);
        void remove(Discounts discounts);

    }
}
