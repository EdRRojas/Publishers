namespace publishers.Api.Dtos.Discounts
{
    public class DiscountsDtosBase : DtosBase
    {
        public string? discounttype { get; set; }
        public int lowqty { get; set; }
        public int highqty { get; set; }
        public decimal discount { get; set; }
    }
}
