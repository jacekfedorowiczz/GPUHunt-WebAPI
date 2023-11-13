using AutoMapper;
using GPUHunt.Models.DTOs.GraphicCard;

namespace GPUHunt.Application.Mappings
{
    public class GraphicCardMappingProfile : Profile
    {
        public GraphicCardMappingProfile()
        {
            CreateMap<Domain.Entities.GraphicCard, GraphicCardDto>()
                .ReverseMap();
        }
    }
}
