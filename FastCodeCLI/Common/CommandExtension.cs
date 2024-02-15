using CliFx.Infrastructure;

namespace CodeCLI.Common;

public static class CommandsExtension
{
    public static void FileCreated(this IConsole console, string name)
        => console.Output.WriteLine($"{name} created successfully.");
}
