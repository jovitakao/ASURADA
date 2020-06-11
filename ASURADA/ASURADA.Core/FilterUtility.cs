using System;
using System.Collections.Generic;
using System.Text;

namespace ASURADA.Core
{
    public class FilterUtility
    {
        public static string ConvertSearchPatternToRegex(string filter)
        {
            //convert match pattern to regex
            foreach (char x in @"\+?|{[()^$.#")
            {
                filter = filter.Replace(x.ToString(), @"\" + x.ToString());
            }
            filter = string.Format("^{0}$", filter.Replace("*", ".*"));
            return filter;
        }
    }
}
