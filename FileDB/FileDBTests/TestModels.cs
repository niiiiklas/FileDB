using FDB.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDBTests
{
    public class TestModels
    {

        public static SimpleKeyValueObj GetSimpleKeyValueObj()
        {
            return new SimpleKeyValueObj
            {
                Id = 12,
                Value = "niklas säger att detta är bra.."
            };
        }
    }


    public class SimpleKeyValueObj
    {
        [KeyAttribute]
        [ColumnAttribute(LengthMax: 8)]
        public int Id { get; set; }

        [ColumnAttribute(LengthMax: 128)]
        public string Value { get; set; }
    }
}
