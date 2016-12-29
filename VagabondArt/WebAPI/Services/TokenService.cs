using Repository.RepositoryInterfaces;
using System;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository m_TokenRepository;

        public TokenService(ITokenRepository tokenRepository)
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
    }
}