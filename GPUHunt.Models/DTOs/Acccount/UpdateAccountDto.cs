namespace GPUHunt.Models.DTOs.Acccount
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Alias { get; set; }
        public string? NewPassword { get; set;}
        public string? CurrentPassword { get; set; }
    }
}
