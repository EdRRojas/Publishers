namespace publishers.Api.Dtos.Roysched
{
    public class RoyschedRemoveDto : RoyschedDtoBase
    {
        public int? userDelete {  get; set; }
        public int? deleted { get; set; }
        public DateTime? deleteTime { get; set; }
    }
}
