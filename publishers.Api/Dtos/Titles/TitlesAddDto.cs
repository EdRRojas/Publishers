namespace publishers.Api.Dtos.Titles
{
    public class TitlesAddDto : TitlesDtoBase
    {
        public string? title_id { get; set; }
        public DateTime? pubdate { get; set; }
    }
}
