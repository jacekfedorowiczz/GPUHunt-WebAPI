using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteAccountCommandHandler(IAccountRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser()!;
            if (int.Parse(user.Id) != request.Id && !(user.IsInRole("Admin") || user.IsInRole("Moderator")))
            {
                throw new ForbidException("Deleting accounts other than your own requires administrative privileges.");
            }

            _repository.DeleteAccount(request.Id);
            return Task.CompletedTask;
        }
    }
}
