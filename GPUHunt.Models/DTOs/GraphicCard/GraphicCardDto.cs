namespace GPUHunt.Models.DTOs.GraphicCard
{
    public class GraphicCardDto
    {
        public string Model { get; set; }
        public string Vendor { get; set; }
        public string Subvendor { get; set; }

        // Information about current prices in stores
        public decimal? ActualMorelePrice { get; set; }
        public decimal? ActualXkomPrice { get; set; }
        public DateTime LastCrawlDate { get; set; }
        public bool IsPriceEqual { get; set; }

        public decimal MoreleLowestPriceEver { get; set; }
        public DateTime MoreleLowestPriceEverCrawlDate { get; set; }
        public decimal LowestPriceEverXkom { get; set; }
        public DateTime XkomLowestPriceEverCrawlDate { get; set; }

        public decimal? MoreleHighestPriceEver { get; set; }
        public DateTime? MoreleHighestPriceEverCrawlDate { get; set; }
        public decimal? XkomHighestPriceEver { get; set; }
        public DateTime? XkomHighestPriceEverCrawlDate { get; set; }
    }
}
