using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GPUHunt.Infrastructure.Repositories
{
    public class GraphicCardRepository : IGraphicCardRepository
    {
        private readonly GPUHuntDbContext _dbContext;

        public GraphicCardRepository(GPUHuntDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<GraphicCard> GetAllGraphicCards() => _dbContext.GraphicCards.Include(gc => gc.Prices).ToList();
        public bool isDatabaseNotEmpty() => _dbContext.GraphicCards.Any();

        public void Crawl(IEnumerable<GraphicCard> graphicCards)
        {
            _dbContext.GraphicCards.AddRange(graphicCards);
            _dbContext.SaveChanges();
        }

        public void Update(IEnumerable<GraphicCard> graphicCards)
        {
            _dbContext.UpdateRange(graphicCards);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var gpu = _dbContext.GraphicCards.FirstOrDefault(g => g.Id == id);

            if (gpu == null)
            {
                throw new NotFoundException("Graphic card not found.");
            }

            _dbContext.GraphicCards.Remove(gpu);
            _dbContext.SaveChanges();
        }


        public PagedResult<GraphicCard> GetGraphicCards(GetGraphicCardQuery query)
        {
            // TODO: Zwracanie kart w paginacji
            throw new NotImplementedException();
        }

    }
}
