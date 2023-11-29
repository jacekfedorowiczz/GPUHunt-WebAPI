using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPUHunt.Domain.Entities
{
    public class GraphicCard
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public Subvendor Subvendor { get; set; }
        public int SubvendorId { get; set; }
        public Prices Prices { get; set; }
    }
}
