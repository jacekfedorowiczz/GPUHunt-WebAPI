using GPUHunt.Models.DTOs.GraphicCard;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Queries.GetAllGraphicCards
{
    public class GetAllGraphicCardsQuery : IRequest<IEnumerable<GraphicCardDto>>
    {
    }
}
