﻿using System.ComponentModel.DataAnnotations;

namespace GPUHunt.Domain.Entities
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
