using GPUHunt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardValidator
    {
        Task<IEnumerable<GraphicCard>> ValidateGPUs();
    }
}
