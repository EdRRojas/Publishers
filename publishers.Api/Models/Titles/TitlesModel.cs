﻿namespace publishers.Api.Models.Titles
{
    public class TitlesModel
    {
        public string title_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string pub_id { get; set; }
        public decimal? price { get; set; }
        public decimal? advance { get; set; }
        public int? royalty { get; set; }
        public int? ytd_sales { get; set; }
        public string? notes { get; set; }
        public DateTime? pubdate { get; set; }
        public int creationUser { get; set; }
        public DateTime creationDate { get; set; }
    }
}