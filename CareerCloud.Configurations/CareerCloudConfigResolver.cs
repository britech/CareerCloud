using Microsoft.Extensions.Configuration;

namespace CareerCloud.Configurations
{
    public class CareerCloudConfigResolver(IConfiguration configuration) : ICareerCloudConfigResolver
    {
        private readonly IConfiguration _configuration = configuration;

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("JOB_PORTAL")!;
        }
    }
}
