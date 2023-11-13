using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Models.Enums;

namespace GPUHunt.Application.Services.CardCrawler
{
    public class CardCrawler : ICardCrawler
    {
        private readonly IEnumerable<IStoreCrawler> _storeCrawlers;
        private readonly ICardComparer _comparer;
        private readonly ICardValidator _validator;
        private readonly ICardUpdater _updater;

        public CardCrawler(IEnumerable<IStoreCrawler> storeCrawlers, ICardComparer comparer, ICardValidator validator, ICardUpdater updater)
        {
            _storeCrawlers = storeCrawlers 
                ?? throw new ArgumentNullException(nameof(storeCrawlers));
            _comparer = comparer 
                ?? throw new ArgumentNullException(nameof(comparer));
            _validator = validator 
                ?? throw new ArgumentNullException(nameof(validator));
            _updater = updater
                ?? throw new ArgumentNullException(nameof(updater));
        }

        public IEnumerable<Domain.Entities.GraphicCard> Crawl(ActionType actionType)
        {
            var gpus = CrawlStores();

            var entities = _comparer.Compare(gpus);

            var validationModel = _validator.ValidateGPU(entities, actionType);

            if (actionType == ActionType.Update)
            {
                _updater.UpdateGraphicCards(validationModel.CardsToUpdate);
            }

            return validationModel.CardsToAdd;
        }

        private IEnumerable<StoreGPU> CrawlStores()
        {
            List<StoreGPU> gpus = new();

            foreach (var storeCrawler in _storeCrawlers)
            {
                var cards = storeCrawler.CrawlStore();
                gpus.AddRange(cards);
            }

            return gpus;
        }
    }
}
