using GPUHunt.Models.DTOs.GraphicCard;
using GPUHunt.Models.Models;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Queries.GetPaginatedGraphicCards
{
    public class GetPaginatedGraphicCardsQuery : IRequest<PagedResult<GraphicCardDto>>
    {
        public GetGraphicCardQuery Query { get; }

        public GetPaginatedGraphicCardsQuery(GetGraphicCardQuery query)
        {
            Query = query;
        }
    }
}
