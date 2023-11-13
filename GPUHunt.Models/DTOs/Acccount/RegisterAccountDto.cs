using System.ComponentModel;

namespace GPUHunt.Models.DTOs.Acccount
{
    public class RegisterAccountDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Alias { get; set; }

        [DefaultValue(1)]
        public int RoleId { get; set; }
    }
}
