using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace UnifiedAppiumTests.Avatrade.Utilities
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration;

        static ConfigurationHelper()
        {

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static string GetSetting(string key)
        {

            return Configuration[key];
        }


        public static string GetAppiumSetting(string settingName)
        {
            return Configuration.GetSection("AppiumSettings")[settingName];
        }
    }
}
