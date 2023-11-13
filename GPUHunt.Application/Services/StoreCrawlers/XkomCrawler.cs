using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Domain.Enums;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Globalization;
using System.Text;

namespace GPUHunt.Application.Services.StoreCrawlers
{
    public class XkomCrawler : IStoreCrawler
    {
        readonly HtmlWeb Web = new();
        readonly NumberFormatInfo nfi = new CultureInfo("pl-PL", false).NumberFormat;
        private readonly String _gpuCardSelector = ".gyHdpL";
        private readonly String _gpuNameSelector = "a > h3";
        private readonly String _gpuPriceSelector = ".gAlJbD > span.guFePW";
        private readonly String _nextSiteSelector = "a.kGuktN";
        private readonly String _optionalGpuNameSelector = ".emYvVh > a > span > img";
        private readonly ICardSetter _cardSetter;

        protected string XKomBaseURL { get; private set; } =
            "https://www.x-kom.pl/g-5/c/345-karty-graficzne.html?f1702-uklad-graficzny=24826-amd-radeon&f1702-uklad-graficzny=24827-nvidia-geforce&f1702-uklad-graficzny=97290-nvidia-quadro&f1702-uklad-graficzny=108431-amd-radeon-pro&f1702-uklad-graficzny=262522-intel-arc";

        public XkomCrawler(ICardSetter cardSetter)
        {
            _cardSetter = cardSetter;
        }

        public IEnumerable<StoreGPU> CrawlStore()
        {
            try
            { 
                var sites = GetSites();
                var GPUs = GetGPUs(sites);
                return GPUs;
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Something went wrong.");
            }
        }

        private IEnumerable<string> GetSites()
        {
            var document = Web.Load(XKomBaseURL);
            var urls = new List<string>() { XKomBaseURL };

            if (document.QuerySelector(_nextSiteSelector).Attributes["href"].Value != null)
            {
                var nextPageUrl = "https://x-kom.pl/" + document.QuerySelector(_nextSiteSelector).Attributes["href"].Value.ToString();
                while (nextPageUrl != null)
                {
                    urls.Add(nextPageUrl);
                    var newDocument = Web.Load(nextPageUrl);
                    if (newDocument.QuerySelector(_nextSiteSelector) != null)
                    {
                        nextPageUrl = "https://x-kom.pl/" + newDocument.QuerySelector(_nextSiteSelector).Attributes["href"].Value.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return urls;
        }

        private IEnumerable<StoreGPU> GetGPUs(IEnumerable<string> sites)
        {
            var gpusList = new List<StoreGPU>();

            foreach (var site in sites)
            {
                var page = Web.Load(site);
                var gpus = page.QuerySelectorAll(_gpuCardSelector);

                foreach (var gpu in gpus)
                {
                    var entity = GetGPUDetails(gpu);
                    if (entity != null)
                    {
                        gpusList.Add(entity);
                    }
                }
            }
            return gpusList;
        }

        private StoreGPU GetGPUDetails(HtmlNode gpu)
        {
            StringBuilder sb = new();
            var gpuModel = gpu.QuerySelector(_gpuNameSelector).LastChild.InnerText.ToString();
            if (String.IsNullOrEmpty(gpuModel))
            {
                gpuModel = gpu.QuerySelector(_optionalGpuNameSelector).Attributes["alt"].Value.ToString();
            }

            var gpuPrice = decimal.Parse(gpu.QuerySelector(_gpuPriceSelector).InnerText.ToString(nfi).Replace("zł", "").Replace("od", ""));

            var gpuName = sb.Append(gpuModel).Insert(0, "Karta graficzna ").ToString();

            Vendors gpuVendor = _cardSetter.SetVendor(gpuName.ToLower());
            Subvendors gpuSubvendor = _cardSetter.SetSubvendor(gpuName.ToLower());

            var result = new StoreGPU
            {
                FullName = gpuName,
                Vendor = gpuVendor,
                Subvendor = gpuSubvendor,
                Model = gpuModel,
                Price = gpuPrice,
                Store = "X-Kom"
            };

            return result;
        }
    }
}
