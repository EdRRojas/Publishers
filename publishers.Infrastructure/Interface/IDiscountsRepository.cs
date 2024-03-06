using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Interface
{
    public interface IDicountsRepository : IBaseRepository<Discounts, string>
    {
        DiscountsModel GetdiscounttypeByName (string name);
        List <DiscountsModel> Getstor_idByID (int id);
        List<DiscountsModel> GetdiscountByDiscounts(decimal discount); 
        
    }
}
