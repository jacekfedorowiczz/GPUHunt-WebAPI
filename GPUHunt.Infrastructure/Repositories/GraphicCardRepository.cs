using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.Models;

namespace GPUHunt.Infrastructure.Repositories
{
    public class GraphicCardRepository : IGraphicCardRepository
    {
        private readonly GPUHuntDbContext _dbContext;

        public GraphicCardRepository(GPUHuntDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Update(IEnumerable<GraphicCard> graphicCards)
        {
            _dbContext.UpdateRange(graphicCards);
            _dbContext.SaveChanges();
        }

        public void AddToFavorites(int id, int userId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == userId);
            var gpu =  _dbContext.GraphicCards.FirstOrDefault(g => g.Id == id);

            if (account == null)
            {
                throw new NotFoundException("User not found.");
            }

            if (gpu == null)
            {
                throw new NotFoundException("Graphic card not found.");
            }

            account.FavoritesGraphicCards.Add(gpu);
            return;
        }

        public void Crawl(IEnumerable<GraphicCard> graphicCards)
        {
            _dbContext.GraphicCards.AddRange(graphicCards);
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

        public IEnumerable<GraphicCard> GetAllGraphicCards() => _dbContext.GraphicCards.ToList();

        public PagedResult<GraphicCard> GetGraphicCards(GetGraphicCardQuery query)
        {
            throw new NotImplementedException();
        }

        public bool isDatabaseNotEmpty()
        {
            return _dbContext.GraphicCards.Any();
        }
    }
}
