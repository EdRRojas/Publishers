namespace publishers.Api.Dtos.Titles
{
    public class TitlesDeleteDto : DtoBase
    {
        public string? title_id { get; set; }
        public bool deleted { get; set; }
    }
}
