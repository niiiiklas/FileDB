using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass]
    public class UsageTest
    {
        [TestMethod]
        public void InitAndSetup()
        {
            var connection = new FDB.FileDBBuilder()
                            .Configuration(
                                new FDB.Configuration.ConfigBuilder()
                                    .SetDefaultDirectory("./testsetups")
                                    .SetUseEncryption(false)
                                    .Build())
                            .Tables(
                                new FDB.Configuration.TablesBuilder()
                                    .AddTable<SimpleKeyValueObj>()
                                    .Build())
                            .Open();
        }
    }
}
