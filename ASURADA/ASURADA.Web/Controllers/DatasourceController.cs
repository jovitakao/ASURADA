using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ASURADA.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASURADA.Web.Controllers
{
    [ApiController]
    public class DatasourceController : ControllerBase
    {
        [Route("api/datasources/datatabases")]
        public async Task<ActionResult<ListResult<string>>> GetDatabases() 
        {
            var dsi = new DataSourceInfo();
            dsi.ConnectionString = "Server=127.0.0.1;Database=test;Uid=root;Pwd=tonyqus;";
            var datasource = DataSourceFactory.Create(dsi);
            var databases=await datasource.GetDatabases("*");
            var result = new ListResult<string>(databases);
            return Ok(result);
        }

        [Route("api/datasources/tables")]
        public ActionResult<QueryResult> GetTables()
        {
            throw new NotImplementedException();
        }
        [Route("api/datasources/runsql")]
        public ActionResult<QueryResult> RunSQL()
        {
            throw new NotImplementedException();
        }
    }
}
