using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Domain.Interfaces;

namespace GPUHunt.Application.Services.ValidatorStrategy
{
    public class ValidationWithUpdateStrategy : IValidationStrategy
    {
        private readonly IGraphicCardRepository _repository;

        public ValidationWithUpdateStrategy(IGraphicCardRepository repository)
        {
            _repository = repository;
        }

        public ValidationModel Validate(IEnumerable<Domain.Entities.GraphicCard> graphicCards)
        {
            ValidationModel model = new() { ActionType = GPUHunt.Models.Enums.ActionType.Update, CardsToUpdate = new List<Domain.Entities.GraphicCard>() };

            var gpusFromDatabase =  _repository.GetAllGraphicCards();

            foreach (var graphicCard in graphicCards)
            {
                var sameGpu = gpusFromDatabase.FirstOrDefault(gd => gd.Model.ToUpper() == graphicCard.Model.ToUpper());
                if (sameGpu != null)
                {
                    var validatedGPU = ValidateGPUsInfo(graphicCard, sameGpu);
                    model.CardsToAdd.Add(validatedGPU);
                }
            }

            return model;

        }

        private Domain.Entities.GraphicCard ValidateGPUsInfo(Domain.Entities.GraphicCard graphicCard, Domain.Entities.GraphicCard gpuFromDatabase)
        {
            if (graphicCard.Prices.MoreleActualPrice >= gpuFromDatabase.Prices.MoreleHighestPriceEver)
            {
                gpuFromDatabase.Prices.MoreleHighestPriceEver = graphicCard.Prices.MoreleActualPrice;
                gpuFromDatabase.Prices.MoreleHighestPriceEverCrawlDate = DateTime.UtcNow;
            }
            else if (graphicCard.Prices.MoreleActualPrice <= gpuFromDatabase.Prices.MoreleLowestPriceEver)
            {
                gpuFromDatabase.Prices.MoreleLowestPriceEver = (decimal)graphicCard.Prices.MoreleActualPrice;
                gpuFromDatabase.Prices.MoreleLowestPriceEverCrawlDate = DateTime.UtcNow;
            }

            if (graphicCard.Prices.XKomActualPrice >= gpuFromDatabase.Prices.XkomHighestPriceEver)
            {
                gpuFromDatabase.Prices.XkomHighestPriceEver = graphicCard.Prices.XKomActualPrice;
                gpuFromDatabase.Prices.XkomHighestPriceEverCrawlDate = DateTime.UtcNow;
            }
            else if (graphicCard.Prices.XKomActualPrice <= gpuFromDatabase.Prices.XkomLowestPriceEver)
            {
                gpuFromDatabase.Prices.XkomLowestPriceEver = (decimal)graphicCard.Prices.XKomActualPrice;
                gpuFromDatabase.Prices.XkomLowestPriceEverCrawlDate = DateTime.UtcNow;
            }

            return gpuFromDatabase;
        }
    }
}
