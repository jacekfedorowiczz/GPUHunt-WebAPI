namespace GPUHunt.Models.DTOs.GraphicCard
{
    public class AccountDto
    {
        public string Alias { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Nationality { get; set; }

        public virtual List<GraphicCardDto> FavoritesGraphicCards { get; set; }
    }
}
