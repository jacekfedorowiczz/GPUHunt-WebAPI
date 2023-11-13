using GPUHunt.Application.Models;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardComparer
    {
        IEnumerable<Domain.Entities.GraphicCard> Compare(IEnumerable<StoreGPU> gpus);
    }
}
