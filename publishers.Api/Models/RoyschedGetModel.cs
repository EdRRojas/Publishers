using publishers.Api.Dtos.Roysched;

namespace publishers.Api.Models
{
    public class RoyschedGetModel 
    {
        public string? title_id { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? lorange { get; set; }
        public int? CreationUser { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
    }
}
