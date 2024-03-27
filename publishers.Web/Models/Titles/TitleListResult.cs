using publishers.Application.Models.Titles;

namespace publishers.Web.Models.Titles
{
    public class TitleListResult : ModelBase
    {        
        public List<TitlesModel>? data { get; set; }
    }
}
