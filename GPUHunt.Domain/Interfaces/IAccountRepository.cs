using GPUHunt.Domain.Entities;
using GPUHunt.Models.DTOs.Acccount;

namespace GPUHunt.Domain.Interfaces
{
    public interface IAccountRepository
    {
        void CreateAccount(RegisterAccountDto registerDto);
        string LoginAccount(LoginAccountDto loginDto); 
        void UpdateAccount(UpdateAccountDto updateDto);
        void DeleteAccount(int id);
        Account GetAccountInfo(int id);
        bool IsEmailInUse(string email);
    }
}
