
namespace publishers.Application.Dtos
{
    public record DtoBase
    {       
        public int UserId { get; set; }
        public DateTime modifyDate { get; set; }
    }
}
