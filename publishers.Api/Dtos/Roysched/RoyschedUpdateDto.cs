using System.ComponentModel.DataAnnotations;

namespace publishers.Api.Dtos.Roysched
{
    public class RoyschedUpdateDto : RoyschedDtoBase
    {
        public int? userMod {  get; set; }
        public DateTime? modifyDate { get; set; }
    }
}
