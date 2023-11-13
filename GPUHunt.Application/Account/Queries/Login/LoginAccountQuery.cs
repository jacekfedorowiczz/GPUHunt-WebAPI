using GPUHunt.Models.DTOs.Acccount;
using MediatR;

namespace GPUHunt.Application.Account.Queries.Login
{
    public class LoginAccountQuery : IRequest<string>
    {
        public LoginAccountQuery(LoginAccountDto dto)
        {
            Dto = dto;
        }

        public LoginAccountDto Dto { get; }
    }
}
