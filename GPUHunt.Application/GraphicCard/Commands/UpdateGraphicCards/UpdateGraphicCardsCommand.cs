using GPUHunt.Models.Enums;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Commands.UpdateGraphicCards
{
    public class UpdateGraphicCardsCommand : IRequest
    {
        public ActionType Action { get; }

        public UpdateGraphicCardsCommand(ActionType action)
        {
            Action = action;
        }
    }
}
