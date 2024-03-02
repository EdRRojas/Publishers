

using System.ComponentModel.DataAnnotations;

namespace publishers.Infrastructure.Models
{
    public class PublishersModel
    {
        [Key]
        public string? pub_id { get; set; }
        public string? pub_name { get; set;}
        public string? city { get; set;}
        public string? state { get; set;}
        public string? country { get; set;}
    }
}
