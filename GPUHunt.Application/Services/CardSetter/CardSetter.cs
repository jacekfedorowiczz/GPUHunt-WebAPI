using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Services.CardSetter
{
    public class CardSetter : ICardSetter
    {
        public Subvendors SetSubvendor(string gpuName)
        {
            var subvendors = Enum.GetNames<Subvendors>();

            for (int i = 0; i < subvendors.Length; i++)
            {
                var x = subvendors[i].ToLower();
                if (gpuName.ToLower().Contains(subvendors[i].ToLower()))
                {
                    return (Subvendors)Enum.Parse(typeof(Subvendors), subvendors[i]);
                }
            }

            return Subvendors.Undefinied;
        }

        public Vendors SetVendor(string gpuName)
        {
            TextInfo textInfo = new CultureInfo("pl-PL", false).TextInfo;
            Vendors vendor;

            if (textInfo.ToLower(gpuName).Contains("geforce") || textInfo.ToLower(gpuName).Contains("quadro") || textInfo.ToLower(gpuName).Contains("gtx") || textInfo.ToLower(gpuName).Contains("rtx"))
            {
                vendor = Vendors.NVIDIA;
            }
            else if (textInfo.ToLower(gpuName).Contains("radeon") || textInfo.ToLower(gpuName).Contains("rx"))
            {
                vendor = Vendors.AMD;
            }
            else if (textInfo.ToLower(gpuName).Contains("intel") || textInfo.ToLower(gpuName).Contains("arc"))
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
