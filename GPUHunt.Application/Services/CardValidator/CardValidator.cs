using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Application.Services.ValidatorStrategy;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Models.Enums;

namespace GPUHunt.Application.Services.CardValidator
{
    public class CardValidator : ICardValidator
    {
        private IValidatorStrategyContext _validatorStrategyContext;
        private readonly IGraphicCardRepository _repository;

        public CardValidator(IValidatorStrategyContext validatorStrategyContext, IGraphicCardRepository repository)
        {
            _validatorStrategyContext = validatorStrategyContext
                ?? throw new ArgumentNullException(nameof(validatorStrategyContext));
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public ValidationModel ValidateGPU(IEnumerable<Domain.Entities.GraphicCard> comparedCards, ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.Init:
                    _validatorStrategyContext.SetStrategy(new ValidationWithoutUpdateStrategy());
                    break;
                case ActionType.Update:
                    _validatorStrategyContext.SetStrategy(new ValidationWithUpdateStrategy(_repository));
                    break;
            }

            var validationModel = _validatorStrategyContext.ExecuteStrategy(comparedCards);

            return validationModel;
        }
    }
}
