using System.ComponentModel.DataAnnotations.Schema;

namespace publishers.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Deleted = 0;//Delete 0 is not deleted/ delete 1 is deleted

        }

        [Column("creationDate")]
        public DateTime? CreationDate { get; set; }

        [Column("deteled")]
        public int? Deleted { get; set; }

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
