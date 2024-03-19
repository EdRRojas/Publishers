namespace publishers.Application.DTO.Roysched
{
    public record RoyschedReomveDto : RoyschedDtoBase
    {
        public DateTime deleteTime;
        public int deleted;
        public int userDelete;
    }
}
