
namespace publishers.Application.Dtos.Titles
{
    public record TitlesDtoAdd : TitlesDtoBase
    {
        public string? pub_id { get; set; }
        public DateTime? pubdate { get; set; }
    }
}
