using DataSource.DataSourceInterfaces;
using System;
using System.Linq;
using System.Text;

namespace DataSource.DataSource
{
    public class AdminDataSource : IAdminDataSource
    {
        public int Authenticate(string userName, string password)
        {
            var adminId = 0;
            
            using (var contex = new VagabondEntities())
            {
                var admin= contex.Admins.FirstOrDefault(s => s.Name == userName);

                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string passwordEncoded = encoding.GetString(Convert.FromBase64String(password));

                if (passwordEncoded == admin.AdminPassword)
                {
                    adminId = admin != null ? admin.Id : adminId;
                }
            }

            return adminId;
        }
    }
}
