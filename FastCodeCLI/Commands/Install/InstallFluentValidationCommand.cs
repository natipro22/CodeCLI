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
            Process.Start("dotnet", arg);
            console.WriteLine("fluent validation installed successfully.");
        }
        catch (Exception e)
        {
            console.Error.WriteLine(e.Message);
        }
        
        return ValueTask.CompletedTask;
    }
}
