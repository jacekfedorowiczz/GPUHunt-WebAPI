using System.ComponentModel.DataAnnotations.Schema;

namespace GPUHunt.Domain.Entities
{
    public class Prices
    {
        public int Id { get; set; }
        public GraphicCard GraphicCard { get; set; }
        [ForeignKey(nameof(GraphicCard))]
        public int GraphicCardId { get; set; }

        public decimal? MoreleActualPrice { get; set; } = null;
        public decimal? XKomActualPrice { get; set; } = null;
        public bool IsPriceEqual { get; set; }
        public DateTime? CrawlTime { get; set; }

        public decimal? MoreleLowestPriceEver { get; set; }
        public DateTime? MoreleLowestPriceEverCrawlDate { get; set; }
        public decimal? XkomLowestPriceEver { get; set; }
        public DateTime? XkomLowestPriceEverCrawlDate { get; set; }

        public decimal? MoreleHighestPriceEver { get; set; }
        public DateTime? MoreleHighestPriceEverCrawlDate { get; set; }
        public decimal? XkomHighestPriceEver { get; set; }
        public DateTime? XkomHighestPriceEverCrawlDate { get; set; }
    }
}
