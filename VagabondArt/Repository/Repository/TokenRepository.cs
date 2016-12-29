using DataSource.DataSource;
using Repository.RepositoryInterfaces;
using Repository.RepositoryModels;

namespace Repository.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ITokenDataSource m_TokenDataSource;
        

        public TokenRepository(ITokenDataSource tokenDataSource)
        {
            m_TokenDataSource = tokenDataSource;
        }

        public bool DeleteByAdminId(int adminId)
        {
           return m_TokenDataSource.DeleteByAdminId(adminId);
        }

        public TokenModelrepository GenerateToken(int adminId)
        {
            var model = m_TokenDataSource.GenerateToken(adminId);

            return new TokenModelrepository
            {
                Id = model.Id,
                AdminId = model.AdminId,
                AuthToken = model.AuthToken,
                ExpiredOn = model.ExpiredOn,
                IssuedOn = model.IssuedOn
            };
        }

        public bool Kill(string tokenId)
        {
            return m_TokenDataSource.Kill(tokenId);
        }

        public bool ValidateToken(string tokenId)
        {
            return m_TokenDataSource.ValidateToken(tokenId);
        }
    }
}
