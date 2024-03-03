using System.ComponentModel.DataAnnotations;

namespace publishers.Api.Models
{
    public class RoyschedAddModel
    {
        [Key]
        public string title_id { get; set; }
        public int lorange { get; set; }
        public int hirange { get; set; }
        public int royalty { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
