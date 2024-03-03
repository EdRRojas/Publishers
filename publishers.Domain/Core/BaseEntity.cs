namespace publishers.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Deleted = false;

        }

        public DateTime CreationDate { get; set; }
        public bool Deleted { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public DateTime ModifyTime { get; set; }
        public int UserDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
