using GPUHunt.Application.Models;
using GPUHunt.Domain.Entities;

namespace GPUHunt.Application.Interfaces
{
    public interface IValidatorStrategyContext
    {
        void SetStrategy (IValidationStrategy strategy);
        ValidationModel ExecuteStrategy(IEnumerable<Domain.Entities.GraphicCard> cards);
    }
}
