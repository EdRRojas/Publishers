using System.ComponentModel.DataAnnotations.Schema;

namespace publishers.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Deleted = false;

        }

        [Column("creationDate")]
        public DateTime? CreationDate { get; set; }

        [Column("deteled")]
        public bool? Deleted { get; set; }

        [Column("creationUser")]
        public int? CreationUser { get; set; }

        [Column("userMod")]
        public int? UserMod { get; set; }


        [Column("modifyDate")]
        public DateTime? ModifyDate { get; set; }

        [Column("userDelete")]
        public int? UserDeleted { get; set; }


        [Column("deteleTime")]
        public DateTime? DeleteTime { get; set; }
    }
}
