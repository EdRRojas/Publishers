using publishers.Api.Dtos.Roysched;
using System.ComponentModel.DataAnnotations;

namespace publishers.Api.Models
{
    public class RoyschedGetModel 
    {
        [Key]
        public string? title_id { get; set; }
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
    }
}
