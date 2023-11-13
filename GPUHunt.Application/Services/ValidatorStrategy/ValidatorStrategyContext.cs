using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;

namespace GPUHunt.Application.Services.ValidatorStrategy
{
    public class ValidatorStrategyContext : IValidatorStrategyContext
    {
        private IValidationStrategy _strategy;

        public void SetStrategy(IValidationStrategy strategy)
        {
            this._strategy = strategy;
        }

        public ValidationModel ExecuteStrategy(IEnumerable<Domain.Entities.GraphicCard> cards)
        {
            var result =  this._strategy.Validate(cards);
            return result;
        }
    }
}
