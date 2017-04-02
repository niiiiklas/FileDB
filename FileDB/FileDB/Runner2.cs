using FDB.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB
{
    public class Runner2
    {

        public static void Main(string[] args)
        {
            try
            {

                new Runner2();
            }
            catch(Exception e)
            {
                string breaky = "";
            }
        }

        public Runner2()
        {
            var asdd = new SimpleKeyValueObj()
            {
                Id = 12,
                Value = "asdasdsa 1212 niklas"
            };


            Console.ReadLine();
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
