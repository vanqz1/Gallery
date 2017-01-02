using System;
using System.Linq;
using DataSource.Model;
using System.Web.Configuration;
using System.Text;

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
            string hoursToExpireToken = WebConfigurationManager.AppSettings["TokenExpirationTimeHours"];
            string token = Guid.NewGuid().ToString();

            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = issuedOn.AddHours(Convert.ToDouble(hoursToExpireToken));

            using (var contex = new VagabondEntities())
            {
                var tokensAdmin = contex.Tokens.Where(s => s.AdminId == adminId);

                foreach (var tokenAdmin in tokensAdmin)
                {
                    contex.Tokens.Remove(tokenAdmin);
                }

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
                    string hoursToExpireToken = WebConfigurationManager.AppSettings["TokenExpirationTimeHours"];
                    token.ExpiredOn = token.ExpiredOn.AddHours(Convert.ToDouble(hoursToExpireToken));
                   
                    contex.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public int Authenticate(string userName, string password)
        {
            var adminId = 0;
            using (var contex = new VagabondEntities())
            {
                var admin = contex.Admins.FirstOrDefault(s => s.Name == userName);
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");

                string passwordEncoded = encoding.GetString(Convert.FromBase64String(admin.AdminPassword));

                if (passwordEncoded == password)
                {
                    adminId = admin != null ? admin.Id : adminId;
                }
            }

            return adminId;
        }
    }
}
