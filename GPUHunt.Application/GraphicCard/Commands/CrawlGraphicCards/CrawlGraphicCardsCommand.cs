using GPUHunt.Models.Enums;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Commands.CrawlGraphicCards
{
    public class CrawlGraphicCardsCommand : IRequest
    {
        public ActionType Action { get; }
        public CrawlGraphicCardsCommand(ActionType action)
        {
            Action = action;
        }
    }
}
