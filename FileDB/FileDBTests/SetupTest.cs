using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDB.Attributes;

namespace FileDBTests
{
    [TestClass]
    public class SetupTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [SegmentLengt]
    class TestObj
    {
        [Key]
        [Column(LengthMax:8)]
        public int Id { get; set; }

        [Column(LengthMax:128)]
        public string Value { get; set; }
    }
}
