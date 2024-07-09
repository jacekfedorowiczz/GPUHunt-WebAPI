using System.ComponentModel.DataAnnotations;

namespace GPUHunt.Domain.Entities
{
    public class Subvendor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Domain.Entities.GraphicCard> GraphicCards { get; set; } = new List<Domain.Entities.GraphicCard>();
    }
}
