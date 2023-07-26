using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.DTOs.Acccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GPUHuntDbContext _dbContext;

        public AccountRepository(GPUHuntDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task CreateAccount(RegisterAccountDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAccount(LoginAccountDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(UpdateAccountDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
