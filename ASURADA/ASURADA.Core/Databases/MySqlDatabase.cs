using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASURADA.Core.Databases
{
    public class MySqlDatabase : IDatabase
    {
        DataSourceInfo dataSourceInfo;
        public MySqlDatabase(DataSourceInfo dataSourceInfo)
        {
            this.dataSourceInfo = dataSourceInfo;
        }
        public async Task<List<TableInfo>> GetTables(string filter)
        {
            filter = FilterUtility.ConvertSearchPatternToRegex(filter);
            List<TableInfo> tables = new List<TableInfo>();
            using (var conn = new MySqlConnection(dataSourceInfo.ConnectionString))
            {
                await conn.OpenAsync();
                var tableSchema = conn.GetSchema("Tables");
                foreach (DataRow r in tableSchema.Rows)
                {
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

        public Task<long> GetTotalRowNumber(string sql)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryResult> RunSQL(string sql)
        {
            QueryResult result = new QueryResult();
            result.Data = new List<object[]>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                using (var conn = new MySqlConnection(dataSourceInfo.ConnectionString))
                {
                    await conn.OpenAsync();
                    var cmd = new MySqlCommand(sql);
                    cmd.Connection = conn;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var newrow = new object[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                newrow[i] = reader[i];
                            }
                            result.Data.Add(newrow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            stopwatch.Stop();
            result.ElapsedTime = stopwatch.ElapsedMilliseconds;
            return result;
        }
    }
}
