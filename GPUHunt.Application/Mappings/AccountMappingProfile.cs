using AutoMapper;
using GPUHunt.Domain.Entities;
using GPUHunt.Models.DTOs.GraphicCard;

namespace GPUHunt.Application.Mappings
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Domain.Entities.Account, AccountDto>()
                .ReverseMap();
        }
    }
}
