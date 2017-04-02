using System;
using System.Collections.Generic;
using System.Text;

namespace FDB.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class KeyAttribute:Attribute { }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IndexAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public int LengthMax { get; set; }
        public ColumnAttribute(int LengthMax)
        {
            this.LengthMax = LengthMax;
        }
    }
}
