using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPUHunt.Domain.Entities;
using GPUHunt.Models.DTOs.Acccount;

namespace GPUHunt.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateAccount(RegisterAccountDto registerDto);
        Task<string> LoginAccount(LoginAccountDto loginDto); 
        Task UpdateAccount(UpdateAccountDto updateDto);
        Task DeleteAccount(int id);
        Task<Account> GetAccountInfo(int id);
    }
}
