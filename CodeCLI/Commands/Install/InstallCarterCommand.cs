using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.DirectoryNamespace;
using System.Diagnostics;

namespace CodeCLI.Commands.Install;
[Command("install carter(c)", "(install|i) (carter|c)$", Description = "Carter is a framework that is a thin layer of extension methods and functionality over ASP.NET Core allowing the code to be more explicit and most importantly more enjoyable.")]
internal class InstallCarterCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        try
        {
            var projectPath = Namespace.GetProjectDirectory();
            string arg = $"add \"{projectPath}\" package carter";
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
        }
        catch (Exception e)
        {
            console.Error.WriteLine(e.Message);
        }
        return ValueTask.CompletedTask;
    }
}
