

namespace publishers.Application.DTO.Roysched
{
    public record RoyschedUpdateDto : RoyschedDtoBase
    {
        public int? userMod { get; set; }
        public DateTime? modifyDate { get; set; }
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
    }
}
