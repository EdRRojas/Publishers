
using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Interfaces
{
    public interface ITitlesRepository : IBaseRepository<Titles, string> 
    {
        TitlesModel GetTitleByName (string title);
        List<TitlesModel> GetTitlesByType(string type);
        List<TitlesModel> GetTitlesByPub(string pub_id);
        List<TitlesModel> GetTitlesByUnderPrice(decimal price);
        List<TitlesModel> GetTitlesByOnPrice(decimal price);
        TitlesModel GetTitleSalesByID(string id);
    }
}
