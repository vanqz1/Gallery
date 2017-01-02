using Repository.RepositoryModels;

namespace Repository.RepositoryInterfaces
{
    public interface ITokenRepository
    {
        bool DeleteByAdminId(int adminId);
        bool Kill(string tokenId);
        TokenModelrepository GenerateToken(int adminId);
        bool ValidateToken(string tokenId);
        int Authenticate(string userName, string password);
    }
}
