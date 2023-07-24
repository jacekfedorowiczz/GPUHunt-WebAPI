using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPUHunt.Models.DTOs.Acccount;

namespace GPUHunt.Domain.Interfaces
{
    public interface IAccountRepository
    {
        // akcje: utwórz konto, zmodyfikuj konto, usuń konto, pobierz dane konta
        Task CreateAccount(RegisterAccountDto registerDto);
        Task<string> LoginAccount(LoginAccountDto loginDto); 
        Task UpdateAccount(UpdateAccountDto updateDto);
        Task DeleteAccount(DeleteAccountDto deleteDto);
        Task<Account> GetAccountInfo(int id);
    }
}
