using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDB.Model
{
    public interface IRow
    {
        int GetKeyLength();
        int GetTotalRowLength();
    }

    public class Row:IRow
    {
        public string ObjTypeName { get; set; }
        public List<RowSegment> Segments { get; set; } = new List<RowSegment>();

        public int GetKeyLength()
        {
            return Segments.Where(x => x.IsKey).First().MaxLengt;
        }

        public int GetTotalRowLength()
        {
            return Segments.Sum(x => x.MaxLengt);
        }
    }

    public class RowSegment
    {
        public bool IsKey { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public SegmentValueType ValueType { get; set; }
        public int MaxLengt { get; set; }
    }

    public enum SegmentValueType
    {
        Int32,
        String
    }
}
