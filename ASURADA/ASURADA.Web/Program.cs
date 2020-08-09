using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASURADA.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASURADA.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                var line = args[1];
                string[] dockerArgs=line.Split(',');
                DataSource = new DataSourceInfo();

                foreach (var argument in dockerArgs)
                {
                    var segment=argument.IndexOf('=');
                    var argName = argument.Substring(0,segment).ToUpper();
                    var argValue = argument.Substring(segment+1).Replace("'","").Replace(""", "");
                    if (argName == "CONNECTION_STRING")
                    {
                        DataSource.ConnectionString = argValue;
                    }
                    else if(argName=="DATASOURCE_TYPE")
                    {
                        DataSource.DataSourceType = argValue;
                    }
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        public static DataSourceInfo DataSource;

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
