using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GPUHunt.Application.Authorization
{
    public class AccountOperationRequirementHandler : AuthorizationHandler<AccountOperationRequirement, Domain.Entities.Account>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountOperationRequirement requirement, Domain.Entities.Account account)
        {
            if (requirement.ResourceOperation == Domain.Enums.ResourceOperation.Create || requirement.ResourceOperation == Domain.Enums.ResourceOperation.Read)
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;

            if (account.Id == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
