using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Domain.Entities;

namespace GPUHunt.Application.Services.ValidatorStrategy
{
    public class ValidationWithoutUpdateStrategy : IValidationStrategy
    {
        public ValidationModel Validate(IEnumerable<Domain.Entities.GraphicCard> graphicCards)
        {
            ValidationModel model = new() { ActionType = GPUHunt.Models.Enums.ActionType.Init };

            foreach (var graphicCard in graphicCards)
            {
                var gpu = ValidatePrices(graphicCard);
                model.CardsToAdd.Add(gpu);
            }

            return model;
        }

        private Domain.Entities.GraphicCard ValidatePrices(Domain.Entities.GraphicCard graphicCard)
        {
            if (graphicCard.Prices.MoreleActualPrice != null)
            {
                graphicCard = SetMorelePrices(graphicCard);
            }
            else if (graphicCard.Prices.XKomActualPrice != null)
            {
                graphicCard = SetXKomPrices(graphicCard);
            }

            return graphicCard;
        }

        private Domain.Entities.GraphicCard SetMorelePrices(Domain.Entities.GraphicCard graphicCard)
        {
            graphicCard.Prices.MoreleLowestPriceEver = (decimal)graphicCard.Prices.MoreleActualPrice;
            graphicCard.Prices.MoreleLowestPriceEverCrawlDate = DateTime.UtcNow;

            return graphicCard;
        }

        private Domain.Entities.GraphicCard SetXKomPrices(Domain.Entities.GraphicCard graphicCard)
        {
            graphicCard.Prices.XkomLowestPriceEver = (decimal)graphicCard.Prices.XKomActualPrice;
            graphicCard.Prices.XkomLowestPriceEverCrawlDate = DateTime.UtcNow;

            return graphicCard;
        }
    }
}
