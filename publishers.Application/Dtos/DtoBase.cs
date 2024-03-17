
namespace publishers.Application.Dtos
{
    public record DtoBase
    {
        public string? title_id { get; set; }
        public int UserId { get; set; }
        public DateTime modifyDate { get; set; }
    }
}
