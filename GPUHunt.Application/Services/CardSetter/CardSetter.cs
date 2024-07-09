using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Enums;

namespace GPUHunt.Application.Services.CardSetter
{
    public class CardSetter : ICardSetter
    {
        private const string _geforce = "geforce";
        private const string _quadro = "quadro";
        private const string _gtx = "gtx";
        private const string _rtx = "rtx";

        private const string _radeon = "radeon";
        private const string _rx = "rx";

        private const string _intel = "intel";
        private const string _arc = "arc";


        public Subvendors SetSubvendor(string gpuName)
        {
            var subvendors = Enum.GetNames<Subvendors>();
            gpuName = gpuName.ToLower();

            for (int i = 0; i < subvendors.Length; i++)
            {
                if (gpuName.Contains(subvendors[i], StringComparison.CurrentCultureIgnoreCase))
                {
                    return (Subvendors)Enum.Parse(typeof(Subvendors), subvendors[i]);
                }
            }

            return Subvendors.Undefinied;
        }

        public Vendors SetVendor(string gpuName)
        {
            Vendors vendor;

            gpuName = gpuName.ToLower();

            if (gpuName.Contains(_geforce) || gpuName.Contains(_quadro) || gpuName.Contains(_gtx) || gpuName.Contains(_rtx))
            {
                vendor = Vendors.NVIDIA;
            }
            else if (gpuName.Contains(_radeon) || gpuName.Contains(_rx))
            {
                vendor = Vendors.AMD;
            }
            else if (gpuName.Contains(_intel) || gpuName.Contains(_arc))
            {
                vendor = Vendors.Intel;
            }
            else
            {
                vendor = Vendors.Undefinied;
            }

            return vendor;
        }
    }
}
