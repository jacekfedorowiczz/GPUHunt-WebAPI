using AutoMapper;
using GPUHunt.Application.Account.Commands.DeleteAccount;
using GPUHunt.Application.Account.Commands.RegisterAccount;
using GPUHunt.Application.Account.Commands.UpdateAccount;
using GPUHunt.Application.Account.Queries.GetAccountById;
using GPUHunt.Application.Account.Queries.Login;
using GPUHunt.Models.DTOs.Acccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GPUHuntWebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private CancellationTokenSource cts;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            cts = new();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountInfo([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetAccountByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterAccountDto registerDto)
        {
            await _mediator.Send(new RegisterAccountCommand(registerDto));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginAccountDto loginDto)
        {
            var token = await _mediator.Send(new LoginAccountQuery(loginDto));
            return Ok(token);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]UpdateAccountDto updateDto)
        {
            await _mediator.Send(new UpdateAccountCommand(updateDto));
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _mediator.Send(new DeleteAccountCommand(id));
            return Ok();
        }
    }
}
