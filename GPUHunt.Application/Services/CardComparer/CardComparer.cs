using GPUHunt.Application.Helpers;
using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Enums;
using System.Text;

namespace GPUHunt.Application.Services.CardComparer
{
    public class CardComparer : ICardComparer
    {
        /// <summary>
        /// Compares collection of graphic cards, which crawled from stores and unify them to object.
        /// </summary>
        /// <param name="gpus"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.GraphicCard> Compare(IEnumerable<StoreGPU> gpus)
        {
            var comparedCards = CreateEntity(gpus);
            return comparedCards;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gpus"></param>
        /// <returns></returns>
        private IEnumerable<Domain.Entities.GraphicCard> CreateEntity(IEnumerable<StoreGPU> gpus)
        {
            List<Domain.Entities.GraphicCard> graphicCards = new();

            foreach ( var gpu in gpus)
            {
                if (graphicCards.FirstOrDefault(gc => gc.Model.ToUpper() == gpu.Model.ToUpper()) == null)
                {
                    var equivalentGPU = gpus.FirstOrDefault(eg => eg.Model.ToUpper() == gpu.Model.ToUpper() && eg.Store.ToUpper() != gpu.Store.ToUpper());

                    if (equivalentGPU == null)
                    {
                        var entity = CreateEntityWithoutComparision(gpu);
                        graphicCards.Add(entity);
                    }
                    else
                    {
                        var entity = CreateEntityAfterComparision(gpu, equivalentGPU); 
                        graphicCards.Add(entity);
                    }
                }
            }

            return graphicCards;
        }

        private Domain.Entities.GraphicCard CreateEntityWithoutComparision(StoreGPU gpu)
        {
            Domain.Entities.GraphicCard graphicCard = new()
            {
                Model = gpu.Model,
                Prices = new Prices()
            };

            graphicCard = ComparerHelper.SetVendorId(graphicCard, gpu);

            switch (gpu.Store)
            {
                case "Morele":
                    graphicCard.Prices.MoreleActualPrice = gpu.Price;
                    graphicCard.Prices.LowestPrice = gpu.Price;
                    graphicCard.Prices.LowestPriceStore = new Store() { Name = gpu.Store};
                    break;
                case "X-Kom":
                    graphicCard.Prices.XKomActualPrice = gpu.Price;
                    graphicCard.Prices.LowestPrice = gpu.Price;
                    graphicCard.Prices.LowestPriceStore = new Store() { Name = gpu.Store };
                    break;
            }

            graphicCard = ComparerHelper.SetSubvendor(graphicCard, gpu);

            return graphicCard;

        }

        private Domain.Entities.GraphicCard CreateEntityAfterComparision(StoreGPU gpu, StoreGPU equivalentGPU)
        {
            Domain.Entities.GraphicCard graphicCard = new()
            {
                Model = gpu.Model,
                Prices = new Prices() { IsPriceEqual = false }
            };
            StringBuilder sb = new(gpu.Store);

            graphicCard = ComparerHelper.SetVendorId(graphicCard, gpu);
            graphicCard = ComparerHelper.SetSubvendor(graphicCard, gpu);

            switch (gpu.Store)
            {
                case "Morele":
                    graphicCard.Prices.MoreleActualPrice = gpu.Price;
                    graphicCard.Prices.XKomActualPrice = equivalentGPU.Price;
                    break;
                case "X-Kom":
                    graphicCard.Prices.XKomActualPrice = gpu.Price;
                    graphicCard.Prices.MoreleActualPrice = equivalentGPU.Price;
                    break;
            }

            if (graphicCard.Prices.MoreleActualPrice == graphicCard.Prices.XKomActualPrice)
            {
                graphicCard.Prices.IsPriceEqual = true;
                graphicCard.Prices.LowestPriceStore = new Store() { Name = sb.Append($", {equivalentGPU.Store}").ToString() };
                graphicCard.Prices.LowestPrice = (decimal)graphicCard.Prices.MoreleActualPrice;
            }

            switch (graphicCard.Prices.MoreleActualPrice < graphicCard.Prices.XKomActualPrice)
            {
                case true:
                    graphicCard.Prices.LowestPrice = (decimal)graphicCard.Prices.MoreleActualPrice;
                    graphicCard.Prices.LowestPriceStore = new Store() { Name = "Morele" };
                    graphicCard.Prices.HighestPrice = (decimal)graphicCard.Prices.XKomActualPrice;
                    graphicCard.Prices.HighestPriceStore = new Store() { Name = "X-Kom" };
                    break;
                case false:
                    graphicCard.Prices.LowestPrice = (decimal)graphicCard.Prices.XKomActualPrice;
                    graphicCard.Prices.LowestPriceStore = new Store() { Name = "X-Kom" };
                    graphicCard.Prices.HighestPrice = (decimal)graphicCard.Prices.MoreleActualPrice;
                    graphicCard.Prices.HighestPriceStore = new Store() { Name = "Morele" };
                    break;
            }

            return graphicCard;
        }
    }
}
