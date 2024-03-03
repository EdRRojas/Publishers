

using publishers.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace publishers.Domain.Entities
{
    public class roysched : BaseEntity
    {
        [Key]
        public string? title_id {  get; set; }
        public int lorange {  get; set; }
        public int hirange { get; set; }
        public int royalty {  get; set; }
    }
}
