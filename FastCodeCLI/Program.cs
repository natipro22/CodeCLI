using CliFx;
using Code.DirectoryNamespace;

await new CliApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync();