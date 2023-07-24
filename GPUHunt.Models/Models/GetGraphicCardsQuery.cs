using GPUHunt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Models.Models
{
    public class GetGraphicCardsQuery
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public string? SearchPhrase { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
