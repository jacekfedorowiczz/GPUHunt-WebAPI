using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Models.DTOs.Acccount
{
    public class RegisterAccountDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Alias { get; set; }

        public int RoleId { get; set; } = 1;
    }
}
