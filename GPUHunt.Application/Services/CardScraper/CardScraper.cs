using AutoMapper;
using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Models.DTOs.GraphicCard;
using Newtonsoft.Json;

namespace GPUHunt.Application.Services.CardScraper
{
    public class CardScraper : ICardScraper
    {
        private readonly IGraphicCardRepository _graphicCardRepository;
        private readonly IMapper _mapper;

        public CardScraper(IGraphicCardRepository graphicCardRepository, IMapper mapper)
        {
            _graphicCardRepository = graphicCardRepository ??
                throw new ArgumentNullException(nameof(graphicCardRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public string Scrap()
        {
            try
            {
                JsonSerializerSettings config = new() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, };

                var gpus = _graphicCardRepository.GetAllGraphicCards();
                var dtos = _mapper.Map<IEnumerable<GraphicCardDto>>(gpus);
                var json = JsonConvert.SerializeObject(dtos, config);

                return json;
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
    }
}
