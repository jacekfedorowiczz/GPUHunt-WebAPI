namespace GPUHunt.Domain.Entities
{
    public class Prices
    {
        public int Id { get; set; }
        public GraphicCard GraphicCard { get; set; }
        public int GraphicCardId { get; set; }

        public decimal? MoreleActualPrice { get; set; }
        public decimal? XKomActualPrice { get; set; }
        public bool IsPriceEqual { get; set; }
        public DateTime CrawlTime { get; set; }

        public decimal LowestPrice { get; set; }
        public Store LowestPriceStore { get; set; }
        public decimal? HighestPrice { get; set; }
        public Store? HighestPriceStore { get; set; }

        public decimal MoreleLowestPriceEver { get; set; }
        public DateTime MoreleLowestPriceEverCrawlDate { get; set; }
        public decimal XkomLowestPriceEver { get; set; }
        public DateTime XkomLowestPriceEverCrawlDate { get; set; }

        public decimal? MoreleHighestPriceEver { get; set; }
        public DateTime? MoreleHighestPriceEverCrawlDate { get; set; }
        public decimal? XkomHighestPriceEver { get; set; }
        public DateTime? XkomHighestPriceEverCrawlDate { get; set; }
    }
}
