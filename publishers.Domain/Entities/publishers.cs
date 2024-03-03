using publishers.Domain.Core;

namespace publishers.Domain.Entities
{
    public class publishers : BaseEntity
    {
        public string? pub_id {  get; set; }
        public string? pub_name { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public int? creationUser { get; set; }
        public DateTime? creationDate { get; set; }
        public int? userMod {  get; set; }
        public DateTime? modifyDate {  get; set; }
        public int? userDelete {  get; set; }
        public DateTime? deteleTime { get; set; }
        public byte? deteled {  get; set; }
    }
}
