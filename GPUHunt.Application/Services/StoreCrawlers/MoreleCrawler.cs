using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Models;
using GPUHunt.Domain.Enums;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Globalization;
using System.Text;

namespace GPUHunt.Application.Services.StoreCrawlers
{
    public class MoreleCrawler : IStoreCrawler
    {
        readonly HtmlWeb Web = new();
        readonly NumberFormatInfo Nfi = new CultureInfo("pl-PL", false).NumberFormat;
        private readonly String _nextSiteSelector = "li.pagination-lg.next > link";
        private readonly String _gpuCardSelector = ".cat-product.card";
        private readonly String _gpuNameSelector = ".cat-product-name > h2 > a";
        private readonly String _gpuPriceSelector = ".price-new";
        private readonly String _characterToAvoid = "(";
        private readonly ICardSetter _cardSetter;

        protected string MoreleBaseURL { get; private set; } =
            "https://www.morele.net/kategoria/karty-graficzne-12/,,,,,,,,0,,,,8143O368064.1800730.1997842.470265.629277.1070067.976407.974080.1163157.955615.955614.1123985.1111434.1258915.2083200.1591770.1649860.1580461.1646742.1576222.1567369.1609819.1497277.1609833.1613601.1967000.1760879.1728675.1689348.1827217.1689340.1827334.1689334.2027819.2073326.2073322.2087937.2119318.2135123.2139481,8143O!2837.!2835,sprzedawca:m/1/?noi";

        public MoreleCrawler(ICardSetter cardSetter)
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
            var document = Web.Load(MoreleBaseURL);
            var urls = new List<string>() { MoreleBaseURL };

            if (document.QuerySelector(_nextSiteSelector).Attributes["href"].Value != null)
            {
                var nextPageUrl = "https://www.morele.net" + document.QuerySelector(_nextSiteSelector).Attributes["href"].Value.ToString();
                while (nextPageUrl != null)
                {
                    urls.Add(nextPageUrl);
                    var newDocument = Web.Load(nextPageUrl);
                    if (newDocument.QuerySelector(_nextSiteSelector) != null)
                    {
                        nextPageUrl = "https://www.morele.net" + newDocument.QuerySelector(_nextSiteSelector).Attributes["href"].Value.ToString();
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

            var gpuName = gpu.QuerySelector(_gpuNameSelector)
                                    .Attributes["title"]
                                    .Value;

            var gpuPrice = decimal.Parse(gpu.QuerySelector(_gpuPriceSelector)
                                    .InnerText
                                    .ToString(Nfi)
                                    .Replace("zł", "")
                                    .Replace("od", ""));


            var start = gpuName.IndexOf("Karta");
            var end = gpuName.LastIndexOf("graficzna");

            if (gpuName.Contains(_characterToAvoid))
            {
                gpuName = gpuName.Substring(0, gpuName.IndexOf(_characterToAvoid)).Trim();
            }

            Vendors gpuVendor = _cardSetter.SetVendor(gpuName.ToLower());
            Subvendors gpuSubvendor = _cardSetter.SetSubvendor(gpuName.ToLower());

            var gpuModel = sb.Append(gpuName).Remove(start, end + 9).ToString().Trim();

            var result = new StoreGPU
            {
                FullName = gpuName,
                Vendor = gpuVendor,
                Subvendor = gpuSubvendor,
                Model = gpuModel,
                Price = gpuPrice,
                Store = "Morele"
            };

            return result;
        }
    }
}
