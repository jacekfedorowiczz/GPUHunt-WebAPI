using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Models
{
    public class StoreGPU
    {
        public string FullName { get; set; }
        public Vendors Vendor { get; set; }
        public Subvendors Subvendor { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Store { get; set; }
    }
}
