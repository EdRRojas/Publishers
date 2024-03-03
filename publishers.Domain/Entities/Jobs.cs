
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace publishers.Domain.Entities
{
    [Table("jobs", Schema = "dbo")]
    public class Jobs 
    {
        [Key]
        public int? job_id { get; set; }
        public string? job_desc { get; set; }
        public int? min_lvl { get; set; }
        public int? max_lvl { get; set; }
        
    }
}
