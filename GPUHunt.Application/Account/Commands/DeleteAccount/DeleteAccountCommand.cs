using MediatR;

namespace GPUHunt.Application.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public DeleteAccountCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
