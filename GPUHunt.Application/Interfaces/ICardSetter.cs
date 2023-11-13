using GPUHunt.Domain.Enums;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardSetter
    {
        Vendors SetVendor(string gpuName);
        Subvendors SetSubvendor(string gpuName);
    }
}
