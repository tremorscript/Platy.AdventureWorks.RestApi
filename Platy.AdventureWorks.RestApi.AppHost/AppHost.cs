using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Platy_AdventureWorks_RestApi>("platy-adventureworks-restapi")
  .WithEndpoint(scheme: "http", name: "platy-adventureworks-restapi");

builder.Build().Run();
