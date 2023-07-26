using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Repositories
{
    public class GraphicCardRepository : IGraphicCardRepository
    {
        private readonly GPUHuntDbContext _dbContext;

        public GraphicCardRepository(GPUHuntDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddToFavorites(int id, int userId)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == userId);
            var gpu = await _dbContext.GraphicCards.FirstOrDefaultAsync(g => g.Id == id);

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

        public async Task Crawl(IEnumerable<GraphicCard> graphicCards)
        {
            await _dbContext.GraphicCards.AddRangeAsync(graphicCards);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var gpu = await _dbContext.GraphicCards.FirstOrDefaultAsync(g => g.Id == id);

            if (gpu == null)
            {
                throw new NotFoundException("Graphic card not found.");
            }

            _dbContext.GraphicCards.Remove(gpu);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GraphicCard>> GetAllGraphicCards() => await _dbContext.GraphicCards.ToListAsync();

        public Task<PagedResult<GraphicCard>> GetGraphicCards(GetGraphicCardsQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isDatabaseEmpty()
        {
            return await _dbContext.Database.CanConnectAsync() 
                ? _dbContext.GraphicCards.Any() 
                : throw new BadRequestException("Something went wrong.");
        }

        public Task Update(GraphicCard graphicCard)
        {
            throw new NotImplementedException();
        }
    }
}
