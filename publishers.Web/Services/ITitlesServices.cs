using publishers.Application.Dtos.Titles;
using publishers.Web.Models.Titles;
using publishers.Web.Services.Core;

namespace publishers.Web.Services
{
    public interface ITitlesServices : IBaseServices<TitleListResult, TitleDetailView, string, TitlesDtoAdd,  TitlesDtoUpdate>
    {
        
    }
}
