using System;
using System.Linq;
using DataSource.Model;

namespace DataSource.DataSource
{
    public class TokenDataSource : ITokenDataSource
    {
        public bool DeleteByAdminId(int adminId)
        {
            using (var contex = new VagabondEntities())
            {
                var tokens = contex.Tokens.Where(s => s.AdminId == adminId);

                foreach (var token in tokens)
                {
                    contex.Tokens.Remove(token);
                }

                contex.SaveChanges();

                var isNotDeleted = contex.Tokens.Any(x => x.AdminId == adminId);

                return !isNotDeleted;
            }
        }

        public TokenModel GenerateToken(int adminId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble(12));

            using (var contex = new VagabondEntities())
            {
                var tokenDomain = new Token
                {
                    AdminId = adminId,
                    AuthToken = token,
                    IssuedOn = issuedOn,
                    ExpiredOn = expiredOn
                };

                contex.Tokens.Add(tokenDomain);
                contex.SaveChanges();
            }

            return new TokenModel(){
                AdminId = adminId,
                IssuedOn = issuedOn,
                ExpiredOn = expiredOn,
                AuthToken = token
            };
        }

        public bool Kill(string tokenId)
        {
            using (var contex = new VagabondEntities())
            {
                var tokens = contex.Tokens.Where(s => s.AuthToken == tokenId);

                foreach (var token in tokens)
                {
                    contex.Tokens.Remove(token);
                }

                contex.SaveChanges();

                var isNotDeleted = contex.Tokens.Any(x => x.AuthToken == tokenId);

                return !isNotDeleted;
            }
        }

        public bool ValidateToken(string tokenId)
        {
            using (var contex = new VagabondEntities())
            {
                var token = contex.Tokens.FirstOrDefault(t => t.AuthToken == tokenId && t.ExpiredOn > DateTime.Now);
                if (token != null && !(DateTime.Now > token.ExpiredOn))
                {
                    token.ExpiredOn = token.ExpiredOn.AddSeconds(Convert.ToDouble(12));
                   
                    contex.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
