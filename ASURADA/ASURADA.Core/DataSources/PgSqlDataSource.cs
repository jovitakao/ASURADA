using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASURADA.Core.DataSources
{
    public class PgSqlDataSource : IDataSource
    {
        public PgSqlDataSource(DataSourceInfo dataSourceInfo)
        {
            ConnectionString = dataSourceInfo.ConnectionString;
        }
        public string ConnectionString { get; set; }

        public async Task<List<string>> GetDatabases(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = "*";
            List<string> databases = new List<string>();

            filter = FilterUtility.ConvertSearchPatternToRegex(filter);

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT datname FROM pg_database";
                using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var dbname = reader[0].ToString();
                        if (dbname == "template1" || dbname == "template0")
                            continue;
                        if (Regex.IsMatch(dbname, filter, RegexOptions.IgnoreCase))
                            databases.Add(dbname);
                    }
                }
            }
            return databases;
        }

    }
}
