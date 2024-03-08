namespace publishers.Api.Models
{
    public class DiscountsAddModel
    {
        public string? discounttype { get; set; }
        public string? stor_id { get; set; }
        public int lowqty { get; set; }
        public int highqty { get; set; }
        public decimal? discount { get; set; }
        public int creationUser { get; set; }
        public DateTime creationDate { get; set; }

    }
}
