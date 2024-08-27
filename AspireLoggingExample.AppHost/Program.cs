var builder = DistributedApplication.CreateBuilder(args);

var appInsights = builder.AddConnectionString("ApplicationInsights", "APPLICATIONINSIGHTS_CONNECTION_STRING");

builder.AddProject<Projects.AspireLoggingExample_Api>("aspireloggingexample-api")
    .WithReference(appInsights);

builder.Build().Run();
