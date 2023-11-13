using GPUHunt.Application.Models;

namespace GPUHunt.Application.Interfaces
{
    public interface IStoreCrawler
    {
        IEnumerable<StoreGPU> CrawlStore();
    }
}
