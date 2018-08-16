using FDB.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDB.Configuration
{
    public class TablesBuilder
    {
        Tables TableSetup { get; set; }

        object[] pages;

        public TablesBuilder()
        {
            TableSetup = new Tables();
        }

        public TablesBuilder AddTable<T>()
        {
            var page = new PageFactory<T>().Build();
            return this;
        }

        public Tables Build()
        {
            return TableSetup;
        }
    }

    public class Tables
    {
    }
}
