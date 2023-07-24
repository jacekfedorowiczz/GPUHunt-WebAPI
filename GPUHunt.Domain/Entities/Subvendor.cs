﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Domain.Entities
{
    public class Subvendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<GraphicCard> GraphicCards { get; set; }
    }
}