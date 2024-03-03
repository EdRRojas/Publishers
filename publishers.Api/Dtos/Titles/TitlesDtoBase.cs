namespace publishers.Api.Dtos.Titles
{
    public class TitlesDtoBase : DtoBase
    {        
        public string? title { get; set; }
        public string? type { get; set; }
        public string? pub_id { get; set; }
        public decimal? price { get; set; }
        public decimal? advance { get; set; }
        public int? royalty { get; set; }
        public int? ytd_sales { get; set; }
        public string? notes { get; set; }        
    }
}
