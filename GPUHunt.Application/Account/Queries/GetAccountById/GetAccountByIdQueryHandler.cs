using GPUHunt.Application.Interfaces;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using MediatR;

namespace GPUHunt.Application.Account.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Domain.Entities.Account>
    {
        private readonly IAccountRepository _repository;
        private readonly IUserContext _userContext;

        public GetAccountByIdQueryHandler(IAccountRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public Task<Domain.Entities.Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || int.Parse(user.Id) != request.Id && !(user.IsInRole("Admin") || user.IsInRole("Moderator")))
            {
                throw new ForbidException("You have to be in role of an admin or a moderator, if you want to get information about the other user's account.");
            }
            var account = _repository.GetAccountInfo(request.Id);
            return Task.FromResult(account);
        }
    }
}
