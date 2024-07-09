using GPUHunt.Models.Models;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Queries.ScrapGraphicCards
{
    public class ScrapGraphicCardsQuery : IRequest<string>
    {
        public GetGraphicCardQuery Query { get; }

        public ScrapGraphicCardsQuery(GetGraphicCardQuery query)
        {
            Query = query;
        }
    }
}
