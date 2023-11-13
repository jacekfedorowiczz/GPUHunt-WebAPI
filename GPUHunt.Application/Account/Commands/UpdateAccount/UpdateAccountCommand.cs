using GPUHunt.Models.DTOs.Acccount;
using MediatR;

namespace GPUHunt.Application.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest
    {
        public UpdateAccountCommand(UpdateAccountDto dto)
        {
            Dto = dto;
        }

        public UpdateAccountDto Dto { get; }
    }
}
