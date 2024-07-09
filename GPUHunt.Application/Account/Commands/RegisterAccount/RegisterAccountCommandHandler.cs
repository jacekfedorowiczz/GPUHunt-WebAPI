using GPUHunt.Application.Account.Commands.RegisterAccount;
using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Commands.CreateAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IAccountRepository _repository;

        public RegisterAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateAccount(request.Dto);
            return Task.CompletedTask;
        }
    }
}
