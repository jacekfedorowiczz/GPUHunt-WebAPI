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
                Prices = new Prices() { CrawlTime = DateTime.UtcNow }
            };

            graphicCard.VendorId = (int)gpu.Vendor;

            switch (gpu.Store)
            {
                case "Morele":
                    graphicCard.Prices.MoreleLowestPriceEverCrawlDate = DateTime.UtcNow;
                    graphicCard.Prices.MoreleActualPrice = gpu.Price;
                    break;
                case "X-Kom":
                    graphicCard.Prices.XkomLowestPriceEverCrawlDate = DateTime.UtcNow;
                    graphicCard.Prices.XKomActualPrice = gpu.Price;
                    break;
            }

            graphicCard.SubvendorId = (int)gpu.Subvendor;

            return graphicCard;

        }

        private Domain.Entities.GraphicCard CreateEntityAfterComparision(StoreGPU gpu, StoreGPU equivalentGPU)
        {
            Domain.Entities.GraphicCard graphicCard = new()
            {
                Model = gpu.Model,
                Prices = new Prices() { IsPriceEqual = false, CrawlTime = DateTime.UtcNow}
            };
            StringBuilder sb = new(gpu.Store);

            graphicCard.VendorId = (int)gpu.Vendor;
            graphicCard.SubvendorId = (int)gpu.Subvendor;

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
                graphicCard.Prices.MoreleLowestPriceEverCrawlDate = DateTime.UtcNow;
                graphicCard.Prices.MoreleLowestPriceEver = (decimal)graphicCard.Prices.MoreleActualPrice;
                graphicCard.Prices.XkomLowestPriceEverCrawlDate = DateTime.UtcNow;
                graphicCard.Prices.XkomLowestPriceEver = (decimal)graphicCard.Prices.XKomActualPrice;
            }

            return graphicCard;
        }
    }
}
