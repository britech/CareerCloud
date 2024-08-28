using Microsoft.Extensions.Configuration;

namespace CareerCloud.Configurations
{
    public class CareerCloudConfigurationLoader
    {
        private static readonly Lazy<CareerCloudConfigurationLoader> _instance = new(() => new CareerCloudConfigurationLoader());
        private readonly IConfiguration _configRoot;

        public static CareerCloudConfigurationLoader Instance {  get { return _instance.Value; } }

        private CareerCloudConfigurationLoader()
        {
            _configRoot = new ConfigurationBuilder()
                .AddIniFile("CareerCloud.ini")
                .Build();
        }

        public string GetConnectionString()
        {
            return _configRoot.GetConnectionString("JOB_PORTAL")!;
        }
    }
}
