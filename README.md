# Minimal repro for Aspire bug

Filed as: https://github.com/dotnet/aspire/issues/13257

## Describe the bug

`.WithPnpm()` plus `.PublishAsDockerFile()` causes `aspire deploy` to fail.

Other package managers, including `.WithNpm()` and `.WithYarn()` succeed.

There is an [existing test](https://github.com/dotnet/aspire/blob/main/tests/Aspire.Hosting.JavaScript.Tests/AddJavaScriptAppTests.cs) that checks for a generated Dockerfile when using `.WithPnpm()`, but I believe the test does not check if the Dockerfile runs.

## Expected Behavior

```
var builder = DistributedApplication.CreateBuilder(args);

builder.AddDockerComposeEnvironment("foo");

var frontend = builder.AddViteApp("frontend", "./frontend")
    // .WithNpm() // works with aspire deploy
    // .WithYarn() // works with aspire deploy
    .WithPnpm() // fails with aspire deploy
    .PublishAsDockerFile();

builder.Build().Run();
```

`aspire deploy`

Should deploy successfully, including successfully building the generated docker files.

## Steps to reproduce

Clone this repo

`aspire deploy`