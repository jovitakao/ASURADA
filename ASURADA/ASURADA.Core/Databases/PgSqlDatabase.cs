using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASURADA.Core.Databases
{
    public class PgSqlDatabase : IDatabase
    {
        DataSourceInfo dataSourceInfo;
        public PgSqlDatabase(DataSourceInfo dataSourceInfo)
        {
            this.dataSourceInfo = dataSourceInfo;
        }
        public async Task<List<TableInfo>> GetTables(string filter)
        {
            filter = FilterUtility.ConvertSearchPatternToRegex(filter);
            List<TableInfo> tables = new List<TableInfo>();
            using (var conn = new NpgsqlConnection(dataSourceInfo.ConnectionString))
            {
                await conn.OpenAsync();
                var tableSchema = conn.GetSchema("Tables");
                foreach (DataRow r in tableSchema.Rows)
                {
                    //var schema = r["table_schema"];
                    var table = r["table_name"].ToString();
                    var type = r["table_type"].ToString();
                    if (Regex.IsMatch(table, filter, RegexOptions.IgnoreCase))
                    {
                        tables.Add(new TableInfo() { TableName = table, TableType = type });
                    }
                }
            }
            return tables;
        }

        public Task<QueryResult> RunSQL(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
