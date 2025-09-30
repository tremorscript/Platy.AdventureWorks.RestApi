using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Platy.AdventureWorks.RestApi.Configurations;

public static class ServiceConfigs
{
  
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
    ILogger logger,
    WebApplicationBuilder builder)
  {
    services.AddAdventureWorkDatabase(builder.Configuration.GetConnectionString("AdventureWorksDb"))
      .AddMediatrConfigs();

    // add a default http client
    services.AddHttpClient("Default");

    logger.LogInformation("{Project} services registered", "Core and Infrastructure services registered");

    return services;
  }
  
}
