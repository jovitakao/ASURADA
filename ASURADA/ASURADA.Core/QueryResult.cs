using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public class QueryResult
    {
        public string ErrorMessage { get; set; }

        public long ElapsedTime { get; set; }
        public List<object[]> Data { get; set; }
    }
}
