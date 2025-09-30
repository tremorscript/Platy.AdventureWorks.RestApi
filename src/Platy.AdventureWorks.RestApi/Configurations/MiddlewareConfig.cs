namespace Platy.AdventureWorks.RestApi.Configurations;

public static class MiddlewareConfig
{
   
  public static async Task<IApplicationBuilder> UseAppMiddleware(this WebApplication app)
  {
    if (app.Environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseDefaultExceptionHandler(); // from FastEndpoints
      app.UseHsts();
    }

    app.UseFastEndpoints()
      .UseSwaggerGen(); // Includes AddFileServer and static files middleware

    app.UseHttpsRedirection();


    return app;
  }
}
