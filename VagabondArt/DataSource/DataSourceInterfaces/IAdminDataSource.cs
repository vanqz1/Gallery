using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DataSourceInterfaces
{
    public interface IAdminDataSource
    {
        int Authenticate(string userName, string password);
    }
}
