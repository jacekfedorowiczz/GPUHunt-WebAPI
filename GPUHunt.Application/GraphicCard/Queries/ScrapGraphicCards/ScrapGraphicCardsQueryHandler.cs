using GPUHunt.Application.Interfaces;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Queries.ScrapGraphicCards
{
    public class ScrapGraphicCardsQueryHandler : IRequestHandler<ScrapGraphicCardsQuery, string>
    {
        private readonly ICardScraper _scraper;
        private readonly IUserContext _userContext;

        public ScrapGraphicCardsQueryHandler(ICardScraper scraper, IUserContext userContext)
        {
            _scraper = scraper ??
                throw new ArgumentNullException(nameof(scraper));
            _userContext = userContext ??
                throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<string> Handle(ScrapGraphicCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = _userContext.GetCurrentUser();
                if (currentUser == null)
                {
                    return string.Empty;
                }
                var serializedGraphicCards = _scraper.Scrap();
                return serializedGraphicCards;
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong.");
            }
        }
    }
}
