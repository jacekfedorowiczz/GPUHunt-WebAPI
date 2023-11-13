using GPUHunt.Application.Interfaces;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Commands.UpdateGraphicCards
{
    public class UpdateGraphicCardsCommandHandler : IRequestHandler<UpdateGraphicCardsCommand>
    {
        private readonly ICardUpdater _updater;
        private readonly ICardCrawler _crawler;

        public UpdateGraphicCardsCommandHandler(ICardUpdater updater, ICardCrawler crawler)
        {
            _updater = updater ??
                throw new ArgumentNullException(nameof(updater));
            _crawler = crawler;
        }

        public async Task Handle(UpdateGraphicCardsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var gpus = _crawler.Crawl(request.Action);
                _updater.UpdateGraphicCards(gpus);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong.");
            }
        }
    }
}
