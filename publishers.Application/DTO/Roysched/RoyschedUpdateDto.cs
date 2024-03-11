

namespace publishers.Application.DTO.Roysched
{
    public record RoyschedUpdateDto : RoyschedDtoBase
    {
        public int? userMod { get; set; }
        public DateTime? modifyDate { get; set; }
    }
}
