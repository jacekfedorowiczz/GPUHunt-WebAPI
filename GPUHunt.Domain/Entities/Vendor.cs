namespace GPUHunt.Domain.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GraphicCard> GraphicCards { get; set; } = new List<GraphicCard>();
    }
}
