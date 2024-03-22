using CliFx;
using CodeCLI.DirectoryNamespace;

await new CliApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync();