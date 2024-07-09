namespace GPUHunt.Domain.Entities
{
    public class FavouriteCards
    {
        public int Id { get; set; }

        public List<GraphicCard> GraphicCards { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
