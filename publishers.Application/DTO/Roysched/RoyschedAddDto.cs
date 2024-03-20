namespace publishers.Application.DTO.Roysched
{
    public record RoyschedAddDto : RoyschedDtoBase
    {
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
    }
}
