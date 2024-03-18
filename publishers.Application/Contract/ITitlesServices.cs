

using publishers.Application.Core;
using publishers.Application.Models.Titles;
using publishers.Application.Dtos.Titles;

namespace publishers.Application.Contract
{
    public interface ITitlesServices
    {
        ServicesResult<List<TitlesModel>> GetTitles();
        ServicesResult<TitlesModel> GetTitle(string title);
        ServicesResult<TitlesModel> CreateTitle(TitlesDtoAdd titlesDtoAdd);
        ServicesResult<TitlesModel> TitlesUpdate(TitlesDtoUpdate titlesDtoUpdate);
        ServicesResult<TitlesModel> TitleRemove(TitlesDtoDelete titlesDtoDelete);
        ServicesResult<TitlesModel> GetTitleByName(string name);
        ServicesResult<List<TitlesModel>> GetTitlesByType(string type);
        ServicesResult<List<TitlesModel>> GetTitlesByPub(string pubId);
        ServicesResult<List<TitlesModel>> GetTitlesByUnderPrice(decimal price);
        ServicesResult<List<TitlesModel>> GetTitlesByOnPrice(decimal price);
    }
}
