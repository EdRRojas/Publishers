
namespace publishers.Application.Dtos.Titles
{
    public record TitlesDtoAdd : TitlesDtoBase
    {        
        public DateTime? pubdate { get; set; }
    }
}
