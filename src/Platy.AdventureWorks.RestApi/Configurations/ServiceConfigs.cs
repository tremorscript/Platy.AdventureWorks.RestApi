using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Platy.AdventureWorks.RestApi.Configurations;

public static class ServiceConfigs
{
  
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration["AdventureWorksDb"];
    if (string.IsNullOrEmpty(connectionString))
    {
      connectionString = Environment.GetEnvironmentVariable("ADVENTUREWORKSDB");
    }

    services.AddAdventureWorkDatabase(connectionString ?? string.Empty);
    
    services.AddMediatrConfigs();

    // add a default http client
    services.AddHttpClient("Default");

    return services;
  }
  
}
