using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASURADA.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASURADA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasourceController : ControllerBase
    {
        public ActionResult<QueryResult> GetDatabases() 
        {
            throw new NotImplementedException();
        }
    }
}
