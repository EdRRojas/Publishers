﻿namespace publishers.Domain.Core
{
    public  abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.creationDate = DateTime.Now;
            this.deleted = false;
        }
        public int creationUser { get; set; }
        public DateTime creationDate { get; set; }
        public int? userMod { get; set; }
        public DateTime? modifyDate { get; set; }
        public int? userDeleted { get; set; }
        public DateTime? deletedDate { get; set; }
        public bool deleted { get; set; }
    }
}
