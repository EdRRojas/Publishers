namespace publishers.Application.DTO.Roysched
{
    public record RoyschedAddDto : RoyschedDtoBase
    {
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
    }
}
