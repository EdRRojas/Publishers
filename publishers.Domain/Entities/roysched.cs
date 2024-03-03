

using publishers.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace publishers.Domain.Entities
{
    [Table("roysched", Schema = "dbo")]
    public class roysched : BaseEntity
    {
        [Key]
        public string? title_id {  get; set; }
        public int? lorange {  get; set; }
        public int? hirange { get; set; }
        public int? royalty {  get; set; }
    }
}
