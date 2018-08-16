using System;
using System.Collections.Generic;
using System.Text;

namespace FDB.Configuration
{
    public class ConfigBuilder
    {
        public ConfigBuilder()
        {

        }


        Config config = Config.GetInstance();

        public ConfigBuilder SetDefaultDirectory(string directoryPath)
        {
            config.RootDirectory = directoryPath;
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
        public static Config ConfigInstance { get; private set; }
        private static Config DEFAULT = new Config()
        {
            RootDirectory = "./FDB_TEST",
            Encrypted = false
        };

        private Config() { }

        public static Config GetInstance()
        {
            if (ConfigInstance == null)
                ConfigInstance = DEFAULT;
            return ConfigInstance;
        }

        public string RootDirectory { get; set; }
        public bool Encrypted { get; set; }
    }
}
