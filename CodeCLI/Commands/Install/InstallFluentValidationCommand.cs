using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.DirectoryNamespace;
using System.Diagnostics;

namespace CodeCLI.Commands.Install;
[Command("install fluent validation", @"^\b(install|i)\b \b(fluent-validation|fv)\b$")]
public class InstallFluentValidationCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        var projectPath = Namespace.GetProjectDirectory();
        string arg = $"add \"{projectPath}\" package FluentValidation.DependencyInjectionExtensions";

        // Start the process
        Process process = Process.Start("dotnet", arg);

        // Wait for the process to exit
        process.WaitForExit();

        // Check the exit code
        int exitCode = process.ExitCode;

        // Dispose the process to release resources
        process.Dispose();

        // Optionally, you can check the exit code and take further actions based on it
        if (exitCode == 0)
        {
            console.Output.WriteLine("Package installed successfully.");
        }
        else
        {
            console.Error.WriteLine($"Package installation failed with exit code {exitCode}.");
        }

        return ValueTask.CompletedTask;
    }
}
