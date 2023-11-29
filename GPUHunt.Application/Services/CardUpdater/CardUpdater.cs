using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Interfaces;

namespace GPUHunt.Application.Services.CardUpdater
{
    public class CardUpdater : ICardUpdater
    {
        private readonly IGraphicCardRepository _repository;

        public CardUpdater(IGraphicCardRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        void ICardUpdater.UpdateGraphicCards(IEnumerable<Domain.Entities.GraphicCard> cardsToUpdate)
        { 
            _repository.Update(cardsToUpdate);
        }
    }
}
