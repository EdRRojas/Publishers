
namespace publishers.Domain.Entities
{
    public class Jobs : BaseEntity
    {
        public int? job_id { get; set; }
        public string? job_desc { get; set; }
        public int min_lvl { get; set; }
        public int max_lvl { get; set; }
        
    }
}
