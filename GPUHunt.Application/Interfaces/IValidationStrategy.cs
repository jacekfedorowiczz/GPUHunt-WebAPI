using GPUHunt.Application.Models;

namespace GPUHunt.Application.Interfaces
{
    public interface IValidationStrategy
    {
        ValidationModel Validate(IEnumerable<Domain.Entities.GraphicCard> graphicCards);
    }
}
