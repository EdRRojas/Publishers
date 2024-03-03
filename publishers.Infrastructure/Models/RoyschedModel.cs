
using System.ComponentModel.DataAnnotations;

namespace publishers.Infrastructure.Models
{
    public class RoyschedModel
    {
        [Key]
        public string? title_id { get; set; }
        public int? lorange { get; set; }
        public int? hirange { get; set; }
        public int? royalty { get; set; }
        public string? title { get; set;}
        public double? price { get; set; }
        public string? type { get; set; }

    }
}
