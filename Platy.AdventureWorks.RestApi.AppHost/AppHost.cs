var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Platy_AdventureWorks_RestApi>("platy-adventureworks-restapi")
  .WithEndpoint(scheme:"http", name: "platy-adventureworks-restapi");

builder.Build().Run();
