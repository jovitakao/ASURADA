using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public class ListResult<T>
    {
        List<T> _data = null;
        public ListResult()
        {
            _data = new List<T>();
        }
        public ListResult(List<T> data)
        {
            _data = data;
        }
        public string ErrorMessage { get; set; }

        public long ElapsedTime { get; set; }
        public List<T> Data
        {
            get
            {
                return _data;
            }
        }
    }
}
