using Microsoft.Extensions.Configuration;

namespace CareerCloud.Configurations
{
    public static class CareerCloudIniLoader
    {
        public static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddIniFile("CareerCloud.ini")
                .Build();
        }
    }
}
