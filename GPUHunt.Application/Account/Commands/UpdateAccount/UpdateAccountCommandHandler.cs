using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _repository;

        public UpdateAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            _repository.UpdateAccount(request.Dto);
            return Task.CompletedTask;
        }
    }
}
