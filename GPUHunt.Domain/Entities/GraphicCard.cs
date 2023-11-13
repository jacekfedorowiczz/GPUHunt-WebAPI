namespace GPUHunt.Domain.Entities
{
    public class GraphicCard
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public Subvendor Subvendor { get; set; }
        public Prices Prices { get; set; }
        public int PricesId { get; set; }
    }
}
