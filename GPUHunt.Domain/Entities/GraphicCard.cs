using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Domain.Entities
{
    public class GraphicCard
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int SubvendorId { get; set; }
        public virtual string Subvendor { get; set; }
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
        public decimal LowestPriceEverXkom { get; set; }
        public DateTime XkomLowestPriceEverCrawlDate { get; set; }

        public decimal? MoreleHighestPriceEver { get; set; }
        public DateTime? MoreleHighestPriceEverCrawlDate { get; set; }
        public decimal? XkomHighestPriceEver { get; set; }
        public DateTime? XkomHighestPriceEverCrawlDate { get; set; }
    }
}
