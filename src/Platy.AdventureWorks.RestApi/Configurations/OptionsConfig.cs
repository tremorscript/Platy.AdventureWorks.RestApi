namespace Platy.AdventureWorks.RestApi.Configurations;

public static class OptionsConfig
{
  public static IServiceCollection AddOptionConfigs(this IServiceCollection services)
  {
    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    return services;
  }
}
