namespace GPUHunt.Application.Interfaces
{
    public interface ICardUpdater
    {
        void UpdateGraphicCards(IEnumerable<Domain.Entities.GraphicCard> cardsToUpdate);
    }
}
