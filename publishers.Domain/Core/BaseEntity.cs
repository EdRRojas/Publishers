using System.Text.Json.Serialization;

namespace publishers.Domain.Core


{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.creationDate = DateTime.Now;
            this.deleted = null;
        }
        [JsonIgnore]
        public int creationUser { get; set; }
        [JsonIgnore]
        public DateTime creationDate { get; set; }
        [JsonIgnore]
        public int? userMod { get; set; }
        [JsonIgnore] 
        public DateTime? modifyDate { get; set; }
        [JsonIgnore] 
        public int? userDelete { get; set; }
        [JsonIgnore] 
        public DateTime? deleteTime { get; set; }
        [JsonIgnore] 
        public bool? deleted { get; set; }
    }
}
