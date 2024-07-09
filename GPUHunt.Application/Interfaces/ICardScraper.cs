using GPUHunt.Models.Models;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardScraper
    {
        string Scrap(GetGraphicCardQuery? query = null);
    }
}
