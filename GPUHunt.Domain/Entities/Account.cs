﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Nationality { get; set; }

        public List<GraphicCard> FavoritesGraphicCards { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
