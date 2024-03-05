using publishers.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace publishers.Domain.Entities
{
    public class Store : BaseEntity
    {

        [StringLength(4, ErrorMessage = "State must be 4 characters")]
        public string? stor_id { get; set; }

        [Required(ErrorMessage = "Store name is required")]
        public string? stor_name { get; set; }

        [Required(ErrorMessage = "Store address is required")]
        public string? stor_address { get; set; }

        [Required(ErrorMessage = "Store city is required")]
        public string? city { get; set; }

        [Required(ErrorMessage = "Store state is required")]
        [StringLength(2, ErrorMessage = "State must be 2 characters")]
        public string? state { get; set; }

        [Required(ErrorMessage = "Store zip is required")]
        [StringLength(5, ErrorMessage = "Zip must be 5 characters")]
        public string? zip { get; set; }

    }
}
