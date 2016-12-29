using DataSource.DataSourceInterfaces;
using System.Linq;

namespace DataSource.DataSource
{
    public class AdminDataSource : IAdminDataSource
    {
        public int Authenticate(string userName, string password)
        {
            var adminId = 0;
            using (var contex = new VagabondEntities())
            {
                var admin= contex.Admins.FirstOrDefault(s => s.Name == userName && s.AdminPassword == password);

                adminId = admin != null ? admin.Id : adminId;
            }

            return adminId;
        }
    }
}
