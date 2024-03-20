
using System.ComponentModel.DataAnnotations;

namespace publishers.Infrastructure.Models
{
    public class TitleModel
    {
        [Key]
        public string? Title { get; set; }
        public double? price { get; set; }
        public string? type { get; set; }
        public string? title_id { get; set; }
    }
}
