using FDB.Attributes;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace FDB.Model.Parser
{
    public partial class Parser
    {


        public static Row ToRow<T>(T obj)
        {
            Row r = new Row();
            r.ObjTypeName = typeof(T).Name;

            var properties = typeof(T).GetRuntimeProperties();
            foreach(var property in properties)
            {
                RowSegment segment = new RowSegment();
                segment.PropertyName = property.Name;

                ApplySegmentValue(obj, property, segment);
                ApplyAttributesData(property, segment);

                r.Segments.Add(segment);
            }

            return r;
        }

        private static void ApplySegmentValue<T>(T obj, PropertyInfo property, RowSegment segment)
        {
            object propertyValue = property.GetValue(obj);

            if (propertyValue is Int32)
            {
                segment.Value = propertyValue.ToString();
                segment.ValueType = SegmentValueType.Int32;
            }
            else if (propertyValue is string)
            {
                segment.Value = propertyValue.ToString();
                segment.ValueType = SegmentValueType.String;
            }
        }

        private static void ApplyAttributesData(PropertyInfo property, RowSegment segment)
        {
            var attributes = property.GetCustomAttributes(true);
            foreach (var attr in attributes)
            {
                KeyAttribute isKey = attr as KeyAttribute;
                if (isKey != null)
                {
                    segment.IsKey = true;
                }

                ColumnAttribute isColumn = attr as ColumnAttribute;
                if (isColumn != null)
                {
                    segment.MaxLengt = isColumn.LengthMax;
                }
            }
        }
    }
}
