using GPUHunt.Domain.Enums;

namespace GPUHunt.Application.Models
{
    public class StoreGPU
    {
        public string FullName { get; set; }
        public Vendors Vendor { get; set; }
        public Subvendors Subvendor { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Store { get; set; }
    }
}
