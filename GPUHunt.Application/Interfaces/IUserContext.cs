using GPUHunt.Application.ApplicationUser;

namespace GPUHunt.Application.Interfaces
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
