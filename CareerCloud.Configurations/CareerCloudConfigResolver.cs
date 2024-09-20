using Microsoft.Extensions.Configuration;

namespace CareerCloud.Configurations
{
    public class CareerCloudConfigResolver : ICareerCloudConfigResolver
    {
        private static readonly Lazy<CareerCloudConfigResolver> _instance = new(() => new CareerCloudConfigResolver());
        private readonly IConfiguration _configRoot;

        public static CareerCloudConfigResolver Instance => _instance.Value;

        private CareerCloudConfigResolver()
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
