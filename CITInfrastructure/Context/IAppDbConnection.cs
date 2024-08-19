using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Context
{
    public interface IAppDbConnection: IDisposable,IAsyncDisposable
    {
        DbConnection dbConnection { get; }
    }
}
