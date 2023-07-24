using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Models.DTOs.Acccount
{
    public class UpdateAccountDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }

        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
