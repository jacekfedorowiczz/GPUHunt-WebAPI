using GPUHunt.Models.Enums;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardCrawler
    {
        IEnumerable<Domain.Entities.GraphicCard> Crawl(ActionType actionType);
    }
}
