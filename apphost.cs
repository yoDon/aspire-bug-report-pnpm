#:sdk Aspire.AppHost.Sdk@13.0.1
#:package Aspire.Hosting.JavaScript@13.0.1
#:package Aspire.Hosting.Docker@13.0.1-preview.1.25575.3

var builder = DistributedApplication.CreateBuilder(args);

builder.AddDockerComposeEnvironment("foo");

var frontend = builder.AddViteApp("frontend", "./frontend")
    // .WithNpm() // works with aspire deploy
    // .WithYarn() // works with aspire deploy
    .WithPnpm() // fails with aspire deploy
    .PublishAsDockerFile();

builder.Build().Run();
