using Microsoft.Data.SqlClient;
using Platy.AdventureWorks.Repository.Domain.Mapping;
public partial class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.AddServiceDefaults();

// Add services to the container.
    builder.Services.AddSerilogOpenTelemetry(builder.Configuration);
    builder.Services.AddAutoMapper(cfg => { }, typeof(AddressProfile)); 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
    builder.Services.AddOptionConfigs();
    builder.Services.AddServiceConfigs(builder.Configuration);
    builder.Services.AddMemoryCache();

    builder.Services.AddFastEndpoints()
      .SwaggerDocument(o =>
      {
        o.ShortSchemaNames = true;
      });

    var app = builder.Build();

    //app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      //app.MapOpenApi();
    }




    await app.UseAppMiddleware();

    app.Run();
  }
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
