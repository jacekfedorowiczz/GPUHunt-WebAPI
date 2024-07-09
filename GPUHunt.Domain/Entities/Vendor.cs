using System.ComponentModel.DataAnnotations;

namespace GPUHunt.Domain.Entities
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GraphicCard> GraphicCards { get; set; } = new List<GraphicCard>();
    }
}
