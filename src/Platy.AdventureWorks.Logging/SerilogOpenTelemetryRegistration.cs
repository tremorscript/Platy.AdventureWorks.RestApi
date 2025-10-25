using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Platy.AdventureWorks.Logging;

public static class SerilogOpenTelemetryRegistration
{
  public static IServiceCollection AddSerilogOpenTelemetry(this IServiceCollection services,
    IConfiguration configuration)
  {
    /*var logger = Log.Logger = new LoggerConfiguration()
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .WriteTo.OpenTelemetry(options =>
      {

        options.Endpoint = configuration["OTEL_EXPORTER_OTLP_ENDPOINT"];
        var headers = configuration["OTEL_EXPORTER_OTLP_HEADERS"]?.Split(',') ?? [];
        foreach (var header in headers)
        {
          var (key, value) = header.Split('=') switch
          {
            [string k, string v] => (k, v),
            var v => throw new Exception($"Invalid header format {v}")
          };

          options.Headers.Add(key, value);
        }
        options.ResourceAttributes.Add("service.name", "apiservice");

        //To remove the duplicate issue, we can use the below code to get the key and value from the configuration

        var (otelResourceAttribute, otelResourceAttributeValue) = configuration["OTEL_RESOURCE_ATTRIBUTES"]?.Split('=') switch
        {
          [string k, string v] => (k, v),
          _ => throw new Exception($"Invalid header format {configuration["OTEL_RESOURCE_ATTRIBUTES"]}")
        };

        options.ResourceAttributes.Add(otelResourceAttribute, otelResourceAttributeValue);
      })
      .CreateLogger();*/

    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    // logger.Information("{Project}", "Logging Configured");
    return services;
  }
}
