using Microsoft.Extensions.Configuration;

namespace CareerCloud.Configurations;

public class DefaultConfigurationLoader
{
    private static readonly Lazy<DefaultConfigurationLoader> _instance = new(() => new DefaultConfigurationLoader());

    public static DefaultConfigurationLoader Instance { get { return _instance.Value; } }

    public IConfiguration Configuration { get; init; }
   
    private DefaultConfigurationLoader()
    {
        Configuration = new ConfigurationBuilder().AddJsonFile("CareerCloud.json").Build();
    }
}
