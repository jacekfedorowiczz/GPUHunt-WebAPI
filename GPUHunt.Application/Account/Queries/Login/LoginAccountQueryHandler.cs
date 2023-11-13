using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Queries.Login
{
    public class LoginAccountQueryHandler : IRequestHandler<LoginAccountQuery, string>
    {
        private readonly IAccountRepository _repository;

        public LoginAccountQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(LoginAccountQuery request, CancellationToken cancellationToken)
        {
            var token = _repository.LoginAccount(request.Dto);
            return Task.FromResult(token);
        }
    }
}
