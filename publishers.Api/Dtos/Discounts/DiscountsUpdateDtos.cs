namespace publishers.Api.Dtos.Discounts
{
    public class DiscountsUpdateDtos : DtosBase
    {
        public string? discounttype { get; set; }
        public string? stor_id { get; set; }
        public int lowqty { get; set; }
        public int highqty { get; set; }
        public decimal discount { get; set; }
    }
}
