using GPUHunt.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardComparer
    {
        Task<IEnumerable<Domain.Entities.GraphicCard>> Compare(IEnumerable<StoreGPU> gpus);
    }
}
