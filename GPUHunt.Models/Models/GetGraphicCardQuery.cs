using GPUHunt.Models.Enums;

namespace GPUHunt.Models.Models
{
    public class GetGraphicCardQuery
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public string? SearchPhrase { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
