using GPUHunt.Domain.Entities;
using GPUHunt.Models.DTOs.Acccount;
using GPUHunt.Models.DTOs.GraphicCard;

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


        void AddGraphicCardToFavorites(GraphicCard graphicCard, int accountId);
        void DeleteGraphicCardFromFavorites(GraphicCard graphicCard, int accountId);
        List<GraphicCardDto> GetFavorites(int accountId);
    }
}
