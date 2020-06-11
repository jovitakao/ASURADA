using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace ASURADA.Core
{
    public interface IDataSource
    {
        Task<List<string>> GetDatabases(string filter);
        string ConnectionString { get; set; }
    }
}
