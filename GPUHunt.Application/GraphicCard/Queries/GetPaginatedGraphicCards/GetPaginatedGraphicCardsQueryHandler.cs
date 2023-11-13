using AutoMapper;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Models.DTOs.GraphicCard;
using GPUHunt.Models.Models;
using MediatR;

namespace GPUHunt.Application.GraphicCard.Queries.GetPaginatedGraphicCards
{
    public class GetPaginatedGraphicCardsQueryHandler : IRequestHandler<GetPaginatedGraphicCardsQuery, PagedResult<GraphicCardDto>>
    {
        private readonly IGraphicCardRepository _graphicCardRepository;
        private readonly IMapper _mapper;

        public GetPaginatedGraphicCardsQueryHandler(IGraphicCardRepository graphicCardRepository, IMapper mapper)
        {
            _graphicCardRepository = graphicCardRepository ??
                throw new ArgumentNullException(nameof(graphicCardRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PagedResult<GraphicCardDto>> Handle(GetPaginatedGraphicCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var graphicCards = _graphicCardRepository.GetGraphicCards(request.Query);
                var dtos = new List<GraphicCardDto>();

                foreach (var graphicCard in graphicCards.Items)
                {
                    var dto = _mapper.Map<GraphicCardDto>(graphicCard);
                    dtos.Add(dto);
                }

                return new PagedResult<GraphicCardDto>(dtos, graphicCards.TotalItemsCount, request.Query.PageSize, request.Query.PageNumber);
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong.");
            }
        }
    }
}
