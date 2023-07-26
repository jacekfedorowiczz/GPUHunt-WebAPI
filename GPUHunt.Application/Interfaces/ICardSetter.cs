using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Interfaces
{
    public interface ICardSetter
    {
        Vendors SetVendor(string gpuName);
        Subvendors SetSubvendor(string gpuName);
    }
}
