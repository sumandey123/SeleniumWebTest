using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestApplication.UiTests.Drivers
{
    public class ConfigurationDriver
    {
        private const string SeleniumBaseUrlConfigFieldName = "seleniumBaseUrl";
        private readonly Lazy<IConfiguration> _configurationLazy;

        public ConfigurationDriver()
        {
            _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);
        }

        public IConfiguration Configuration => _configurationLazy.Value;

        public string SeleniumBaseUrl => Configuration[SeleniumBaseUrlConfigFieldName];

        private IConfiguration GetConfiguration()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectoryInfo = Directory.GetParent(currentDirectory);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(parentDirectoryInfo.FullName + "\\NUnitTestProject1\\")
                .AddJsonFile(@"test-appsettings.json", optional: false, reloadOnChange: true);

            return configurationBuilder.Build();


            //var configurationBuilder = new ConfigurationBuilder();

            //string directoryName = Path.GetDirectoryName(typeof(ConfigurationDriver).Assembly.Location);
            //configurationBuilder.AddJsonFile(Path.Combine(directoryName, @"test-appsettings.json"));

            //return configurationBuilder.Build();
        }
    }
}