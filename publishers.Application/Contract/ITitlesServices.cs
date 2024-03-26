

using publishers.Application.Core;
using publishers.Application.Models.Titles;
using publishers.Application.Dtos.Titles;

namespace publishers.Application.Contract
{
    public interface ITitlesServices : IBaseServices<TitlesModel, TitlesDtoAdd, TitlesDtoUpdate, TitlesDtoDelete, string>
    {
        ServicesResult<TitlesModel> GetTitleByName(string name);
        ServicesResult<List<TitlesModel>> GetTitlesByType(string type);
        ServicesResult<List<TitlesModel>> GetTitlesByPub(string pubId);
        ServicesResult<List<TitlesModel>> GetTitlesByUnderPrice(decimal price);
        ServicesResult<List<TitlesModel>> GetTitlesByOnPrice(decimal price);
        ServicesResult<TitlesModel> GetTitleSalesByID(string id);
    }
}
