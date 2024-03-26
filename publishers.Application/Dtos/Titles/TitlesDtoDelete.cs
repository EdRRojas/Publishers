

namespace publishers.Application.Dtos.Titles
{
    public record TitlesDtoDelete : DtoBase
    {
        public string? title_id { get; set; }
        public bool deleted { get; set; }
    }
}
