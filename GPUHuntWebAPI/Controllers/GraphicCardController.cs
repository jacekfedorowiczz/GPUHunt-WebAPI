using AutoMapper;
using GPUHunt.Application.GraphicCard.Commands.CrawlGraphicCards;
using GPUHunt.Application.GraphicCard.Queries.ScrapGraphicCards;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Repositories;
using GPUHunt.Models.Enums;
using GPUHunt.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPUHuntWebAPI.Controllers
{
    [Route("api/gpus")]
    [ApiController]
    public class GraphicCardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGraphicCardRepository _repository;

        public GraphicCardController(IMediator mediator, IMapper mapper, IGraphicCardRepository repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetGraphicCards([FromBody]GetGraphicCardQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("crawl")]
        public async Task<IActionResult> Crawl()
        {
            if (!_repository.isDatabaseNotEmpty()) 
                await _mediator.Send(new CrawlGraphicCardsCommand(ActionType.Init));

            return Ok();
        }

        [HttpGet("scrap")]
        public async Task<IActionResult> Scrap()
        {
            if (!_repository.isDatabaseNotEmpty())
            {
                return NotFound();
            }

            var result = await _mediator.Send(new ScrapGraphicCardsQuery());
            return Ok(result);
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update()
        {
            if (_repository.isDatabaseNotEmpty())
                await _mediator.Send(new CrawlGraphicCardsCommand(ActionType.Update));

            return Ok();
        }
    }
}
