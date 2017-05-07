using Repository.RepositoryInterfaces;
using System;
using System.Text;
using Services.Interfaces;
using Services.Models;

namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenRepository m_TokenRepository;

        public  const string GetOriginUrl = "http://vagabond-ichko.c9users.io:8080";

        public AuthenticationService(ITokenRepository tokenRepository)
        {
            m_TokenRepository = tokenRepository;
        }

        public bool DeleteByAdminId(int adminId)
        {
            return m_TokenRepository.DeleteByAdminId(adminId);
        }

        public Token GenerateToken(int adminId)
        {
           var token =  m_TokenRepository.GenerateToken(adminId);

            return new Token
            {
                Id = token.Id,
                AdminId = token.AdminId,
                AuthToken = token.AuthToken,
                ExpiredOn = token.ExpiredOn,
                IssuedOn = token.IssuedOn
            };
        }

        public bool Kill(string tokenId)
        {
            return m_TokenRepository.Kill(tokenId);
        }

        public bool ValidateToken(string tokenId)
        {
            return m_TokenRepository.ValidateToken(tokenId);
        }

        public int Authenticate(string authHeader)
        {
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int seperatorIndex = usernamePassword.IndexOf(':');

            var username = usernamePassword.Substring(0, seperatorIndex);
            var password = usernamePassword.Substring(seperatorIndex + 1);

            var adminId = m_TokenRepository.Authenticate(username, password);

            return adminId;
        }

        public bool IsAuthorized(string authToken)
        {
            var isAuthorized = false;

            if (!string.IsNullOrEmpty(authToken))
            {
                isAuthorized = ValidateToken(authToken);
            }
            return isAuthorized;
        }
    }
}