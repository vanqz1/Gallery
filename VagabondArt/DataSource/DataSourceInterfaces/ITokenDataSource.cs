using DataSource.Model;

namespace DataSource.DataSource
{
    public interface ITokenDataSource
    {
        bool DeleteByAdminId(int adminId);
        bool Kill(string tokenId);
        TokenModel GenerateToken(int adminId);
        bool ValidateToken(string tokenId);
    }
}