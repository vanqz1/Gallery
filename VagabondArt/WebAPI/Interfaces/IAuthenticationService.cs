using WebAPI.Models;

namespace WebAPI.Interfaces
{ 
    public interface IAuthenticationService
    {
        Token GenerateToken(int userId);
        bool ValidateToken(string tokenId);
        bool Kill(string tokenId);
        bool DeleteByAdminId(int userId);
        int Authenticate(string authHeader);
        bool IsAuthorized(string authToken);
    }
}