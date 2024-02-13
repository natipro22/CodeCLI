using CliFx;
using Code.DirectoryNamespace;

await new CliApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync();
string @namespace = Namespace.GetNamespace();