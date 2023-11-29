using GPUHunt.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace GPUHunt.Application.Authorization
{
    public class AccountOperationRequirement : IAuthorizationRequirement
    {
        public AccountOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }

        public ResourceOperation ResourceOperation { get; }
    }
}
