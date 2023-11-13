using GPUHunt.Application.Models;
using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Enums;

namespace GPUHunt.Application.Helpers
{
    public static class ComparerHelper
    {
        public static Domain.Entities.GraphicCard SetVendorId(Domain.Entities.GraphicCard graphicCard, StoreGPU gpu)
        {
            switch (gpu.Vendor)
            {
                case Vendors.NVIDIA:
                    graphicCard.VendorId = 1;
                    break;
                case Vendors.AMD:
                    graphicCard.VendorId = 2;
                    break;
                case Vendors.Intel:
                    graphicCard.VendorId = 3;
                    break;
                default:
                    graphicCard.VendorId = 4;
                    break;
            }

            return graphicCard;
        }

        public static Domain.Entities.GraphicCard SetSubvendor(Domain.Entities.GraphicCard graphicCard, StoreGPU gpu)
        {
            graphicCard.Subvendor.Name = gpu.Subvendor.ToString();

            return graphicCard;
        }
    }
}
