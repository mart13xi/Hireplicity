var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hireplicity_CodeChallenge_Api>("hireplicity-codechallenge-api");

builder.Build().Run();
