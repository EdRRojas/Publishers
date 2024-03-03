using System.ComponentModel.DataAnnotations;

namespace publishers.Api.Dtos.Roysched
{
    public class RoyschedAddDto : RoyschedDtoBase
    {
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }

        
    }
}
