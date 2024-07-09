using GPUHunt.Models.Enums;

namespace GPUHunt.Application.Models
{
    public class ValidationModel
    {
        public ValidationModel(ActionType actionType)
        {
            ActionType = actionType;
        }

        public ActionType ActionType { get; set; }
        public List<Domain.Entities.GraphicCard> CardsToAdd { get; set; } = new List<Domain.Entities.GraphicCard>();
        public List<Domain.Entities.GraphicCard>? CardsToUpdate { get; set; }
    }
}
