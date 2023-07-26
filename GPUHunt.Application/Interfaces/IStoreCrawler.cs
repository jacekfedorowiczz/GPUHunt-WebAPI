using GPUHunt.Application.Models;
using GPUHunt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Interfaces
{
    public interface IStoreCrawler
    {
        Task<IEnumerable<StoreGPU>> CrawlStore();
    }
}
