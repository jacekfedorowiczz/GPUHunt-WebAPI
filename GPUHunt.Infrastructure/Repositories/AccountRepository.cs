using AutoMapper;
using GPUHunt.Application.Authentication;
using GPUHunt.Domain.Entities;
using GPUHunt.Domain.Exceptions;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Models.DTOs.Acccount;
using GPUHunt.Models.DTOs.GraphicCard;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GPUHunt.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GPUHuntDbContext _dbContext;
        private readonly IPasswordHasher<Account> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountRepository(GPUHuntDbContext dbContext, IPasswordHasher<Account> passwordHasher, IMapper mapper, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _authenticationSettings = authenticationSettings ?? throw new ArgumentNullException(nameof(authenticationSettings));
        }

        #region Account CRUD
        public void CreateAccount(RegisterAccountDto registerDto)
        {
            var newAccount = new Account()
            {
                Alias = registerDto.Alias,
                Email = registerDto.Email,
                RoleId = registerDto.RoleId,
            };

            var hashedPassword = _passwordHasher.HashPassword(newAccount, registerDto.Password);

            newAccount.PasswordHash = hashedPassword;

            _dbContext.Accounts.Add(newAccount);
            _dbContext.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var account = GetAccountById(id);

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }

        public Account GetAccountInfo(int id)
        {
            var account = GetAccountById(id);

            return account;
        }

        public string LoginAccount(LoginAccountDto loginDto)
        {
            var account = _dbContext.Accounts
                           .Include(u => u.Role)
                           .FirstOrDefault(u => u.Email == loginDto.Email);

            if (account is null)
            {
                throw new NotFoundException("Incorrect email address or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Incorrect email address or password.");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public void UpdateAccount(UpdateAccountDto updateDto)
        {
            var account = GetAccountById(updateDto.Id);

            if (!string.IsNullOrWhiteSpace(updateDto.NewPassword))
            {
                var isCurrentPasswordCorrect = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, updateDto.CurrentPassword);
                if (isCurrentPasswordCorrect == PasswordVerificationResult.Success)
                {
                    var hashedPassword = _passwordHasher.HashPassword(account, updateDto.NewPassword);
                    account.PasswordHash = hashedPassword;
                }
            }
            
            if (!string.IsNullOrWhiteSpace(updateDto.Email))
            {
                account.Email = updateDto.Email;

            }

            if(!string.IsNullOrWhiteSpace(updateDto.Alias))
            {
                account.Alias = updateDto.Alias;
            }

            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }

        public bool IsEmailInUse(string email)
        {
            return _dbContext.Accounts.Any(a => a.Email == email);
        }
        #endregion

        #region Favorites 
        public void AddGraphicCardToFavorites(GraphicCard graphicCard, int accountId)
        {
            var account = GetAccountById(accountId);

            account.FavoritesGraphicCards.Add(graphicCard);
            _dbContext.SaveChanges();
        }

        public void DeleteGraphicCardFromFavorites(GraphicCard graphicCard, int accountId)
        {
            var account = GetAccountById(accountId);

            account.FavoritesGraphicCards.Remove(graphicCard);
            _dbContext.SaveChanges();
        }

        public List<GraphicCardDto> GetFavorites(int accountId)
        {
            var account = GetAccountById(accountId);

            var graphicCards = account.FavoritesGraphicCards.ToList();
            var dtos = new List<GraphicCardDto>();

            foreach (var graphicCard in graphicCards)
            {
                var dto = _mapper.Map<GraphicCardDto>(graphicCard);
                dtos.Add(dto);
            }

            return dtos;
        }
        #endregion

        #region Private methods
        private Account GetAccountById(int id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                throw new NotFoundException("Account not found.");
            }

            return account;
        }
        #endregion
    }
}
