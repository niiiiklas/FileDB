using System;
using FDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass]
    public class Parser
    {
        [TestMethod]
        public void ToRowParser()
        {
            var obj = TestModels.GetSimpleKeyValueObj();
            var parsed = FDB.Model.Parser.Parser.ToRow(obj);

            Assert.IsTrue(parsed != null);
            Assert.IsTrue(parsed.Segments.Count > 0);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestPage()
        {
            var obj = TestModels.GetSimpleKeyValueObj();

            //FDB.Model.Page<SimpleKeyValueObj> page = new FDB.Model.Page<SimpleKeyValueObj>()
            //{

            //}
        }
    }
}
