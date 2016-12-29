using WebAPI.Models;

namespace WebAPI.Interfaces
{ 
    public interface ITokenService
    {
        Token GenerateToken(int userId);
        bool ValidateToken(string tokenId);
        bool Kill(string tokenId);
        bool DeleteByAdminId(int userId);
    }
}