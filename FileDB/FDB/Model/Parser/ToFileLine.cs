using FDB.Attributes;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace FDB.Model.Parser
{
    public partial class Parser
    {
        public static string ToStringLine(Row row)
        {
            StringBuilder strB = new StringBuilder();
            
            foreach(var seg in row.Segments)
            {
                strB.Append(seg.Value);
            }
            return strB.ToString();
        }
    }
}
