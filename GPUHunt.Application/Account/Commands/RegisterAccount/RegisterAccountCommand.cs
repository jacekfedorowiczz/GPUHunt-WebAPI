using GPUHunt.Models.DTOs.Acccount;
using MediatR;

namespace GPUHunt.Application.Account.Commands.RegisterAccount
{
    public class RegisterAccountCommand : IRequest
    {
        public RegisterAccountDto Dto { get; }

        public RegisterAccountCommand(RegisterAccountDto dto)
        {
            Dto = dto;
        }
    }
}
