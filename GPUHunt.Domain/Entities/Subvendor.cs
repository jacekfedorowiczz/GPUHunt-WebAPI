namespace GPUHunt.Domain.Entities
{
    public class Subvendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Domain.Entities.GraphicCard> GraphicCards { get; set; } = new List<Domain.Entities.GraphicCard>();
    }
}
