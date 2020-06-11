using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ASURADA.Core
{
    public interface IDatabase
    {

        Task<List<TableInfo>> GetTables(string filter);
        Task<QueryResult> RunSQL(string sql);

    }
}
