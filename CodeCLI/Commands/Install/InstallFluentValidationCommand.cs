using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.DirectoryNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Install;
[Command("install fluent validation", "(install|i) (fluent-validation|fv)$")]
public class InstallFluentValidationCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        try
        {
            var projectPath = Namespace.GetProjectDirectory();
            string arg = $"add \"{projectPath}\" package FluentValidation.AspNetCore";

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
