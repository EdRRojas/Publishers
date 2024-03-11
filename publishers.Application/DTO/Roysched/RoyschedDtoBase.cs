namespace publishers.Application.DTO.Roysched
{
    public record RoyschedDtoBase : DtoBase
    {
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
        public string? title_id { get; set; }
    }
}
