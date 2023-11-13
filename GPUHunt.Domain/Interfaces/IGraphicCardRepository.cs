using GPUHunt.Domain.Entities;
using GPUHunt.Models.Models;

namespace GPUHunt.Domain.Interfaces
{
    public interface IGraphicCardRepository
    {
        PagedResult<GraphicCard> GetGraphicCards(GetGraphicCardQuery query);
        IEnumerable<GraphicCard> GetAllGraphicCards();
        void Crawl(IEnumerable<GraphicCard> graphicCards);
        void Update (IEnumerable<GraphicCard> graphicCards);
        void Delete(int id);
        bool isDatabaseNotEmpty();
        void AddToFavorites(int id, int userId);
    }
}
