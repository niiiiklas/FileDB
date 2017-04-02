using System;
using System.Collections.Generic;
using System.Text;

namespace FDB.Configuration
{
    public class ConfigBuilder
    {
        private ConfigBuilder() { }


        Config config = new Config();
        public static ConfigBuilder NewBuilder()
        {
            return new ConfigBuilder();
        }

        public ConfigBuilder SetDefaultDirectory(string directoryPath)
        {
            config.DefaultDirectory = directoryPath;
            return this;
        }


        public ConfigBuilder SetUseEncryption(bool encrypt)
        {
            config.Encrypted = encrypt;
            return this;
        }

        public Config Build()
        {
            return config;
        }
    }

    public class Config
    {
        public string DefaultDirectory { get; set; }
        public bool Encrypted { get; set; }
    }
}
