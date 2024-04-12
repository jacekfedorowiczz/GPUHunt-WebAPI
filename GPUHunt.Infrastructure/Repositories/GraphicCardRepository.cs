using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.Enums;
using GPUHunt.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            var baseQuery = _dbContext
                                .GraphicCards
                                .Include(g => g.Vendor)
                                .Where(g => query.SearchPhrase == null || g.Model.ToLower().Contains(query.SearchPhrase.ToLower()))
                                .AsNoTracking()
                                .AsQueryable();

            var columnSelectors = new Dictionary<string, Expression<Func<GraphicCard, object>>>
            {
                { nameof(GraphicCard.Model), g => g.Model },
                { nameof(GraphicCard.Vendor), g => g.Vendor },
                { nameof(GraphicCard.Subvendor), g => g.Subvendor },
            };

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var selectedColumn = columnSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var graphicCards = baseQuery
                    .Skip(query.PageSize * (query.PageNumber - 1))
                    .Take(query.PageSize)
                    .ToList();

            var totalCount = baseQuery.Count();

            return new PagedResult<GraphicCard>(graphicCards, totalCount, query.PageSize, query.PageNumber);
        }

    }
}
