using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public class QueryResult
    {
        public string ErrorMessage { get; set; }

        public int QueryElapsedTime { get; set; }
        public object[][] Data { get; set; }
    }
}
