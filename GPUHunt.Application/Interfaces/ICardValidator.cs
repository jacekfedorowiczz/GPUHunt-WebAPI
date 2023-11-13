using GPUHunt.Application.Models;
using GPUHunt.Models.Enums;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardValidator
    {
        ValidationModel ValidateGPU(IEnumerable<Domain.Entities.GraphicCard> comparedCards, ActionType actionType);
    }
}
