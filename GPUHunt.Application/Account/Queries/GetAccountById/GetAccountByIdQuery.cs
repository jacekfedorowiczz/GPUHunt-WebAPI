using MediatR;

namespace GPUHunt.Application.Account.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<Domain.Entities.Account>
    {
        public int Id { get; }

        public GetAccountByIdQuery(int id)
        {
            Id = id;
        }

    }
}
