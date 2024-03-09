
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace publishers.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.creationDate = DateTime.Now;
            this.deteled = 1;
        }
        [Column("creationUser")]
        public int creationUser { get; set; }

        [Column("creationDate")]
        public DateTime creationDate { get; set; }

        [Column("userMod")]
        public int? userMod { get; set; }

        [Column("modifyDate")]
        public DateTime? modifyDate { get; set; }

        [Column("userDeleted")]
        public int? userDeleted { get; set; }

        [Column("deteleTime")]
        public DateTime? deteleTime { get; set; }

        [Column("detele")]
        public int deteled {  get; set; }
    }
}
