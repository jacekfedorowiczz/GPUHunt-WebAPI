using GPUHunt.Application.Account.Commands.RegisterAccount;
using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Commands.CreateAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IAccountRepository _repository;
        private readonly IUserContext _userContext;

        public RegisterAccountCommandHandler(IAccountRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            if (request.Dto.RoleId > 1 && user == null || request.Dto.RoleId > 1 && !(user.IsInRole("Admin") || user.IsInRole("Moderator")))
            {
                throw new ForbidException("Adding a user with a role other than 'user' is forbidden. Check if you have the admin or moderator.");
            }

            _repository.CreateAccount(request.Dto);
            return Task.CompletedTask;
        }
    }
}
