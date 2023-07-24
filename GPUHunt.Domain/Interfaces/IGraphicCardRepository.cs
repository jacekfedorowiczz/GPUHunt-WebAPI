using GPUHunt.Domain.Entities;
using GPUHunt.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Domain.Interfaces
{
    public interface IGraphicCardRepository
    {
        Task<PagedResult<GraphicCard>> GetGraphicCards(GetGraphicCardsQuery query);
        Task<IEnumerable<GraphicCard>> GetAllGraphicCards();
        Task Crawl(IEnumerable<GraphicCard> graphicCards);
        Task Update (GraphicCard graphicCard);
        Task Delete(int id);
        Task<bool> isDatabaseEmpty();

        Task AddToFavorites(int id);
    }
}
