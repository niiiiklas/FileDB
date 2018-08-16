using System;

namespace FDB
{
    public class FileDBBuilder
    {
        public FileDBBuilder() {  }

        Configuration.Config Config { get; set; }
        Configuration.Tables TableSetup { get; set; }

        public FileDBBuilder Configuration(Configuration.Config config)
        {
            Config = config;
            return this;
        }

        public FileDBBuilder Tables(Configuration.Tables tables)
        {
            TableSetup = tables;
            return this;
        }

        public FileDBConnection Open()
        {
            return new FileDBConnection();
        }
        
    }

    public class FileDBConnection
    {

    }
}
