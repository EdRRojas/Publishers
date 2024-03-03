using publishers.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace publishers.Domain.Entities
{
    public class Store : BaseEntity
    {
        
        public string? stor_id { get; set; }
        
        [Required(ErrorMessage = "Store name is required")]
        public string? stor_name { get; set; }

        [Required(ErrorMessage = "Store address is required")]
        public string? stor_address { get; set; }

        [Required(ErrorMessage = "Store city is required")]
        public string? city { get; set; }

        [Required(ErrorMessage = "Store state is required")]
        public string? state { get; set; }
        
        [Required(ErrorMessage = "Store zip is required")]
        public string? zip { get; set; }
    }
}
