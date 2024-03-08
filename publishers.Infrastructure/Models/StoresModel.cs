

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace publishers.Infrastructure.Models
{
    public class StoresModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? stor_id { get; set; }
        public string? stor_name { get; set; }
        public string? stor_address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int zip { get; set; }
    }
}
