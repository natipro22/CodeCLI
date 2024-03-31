using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands;

namespace FastCodeCLI.Commands.Dot;
[Command("dot", "^[.]$", Description = "Launch Visual studio with the specified solution")]
public class DotCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string[] getFiles = Directory.GetFiles(currentDirectory, "*.sln");
        if (getFiles.Any())
        {
            string solution = getFiles.First();
            Process.Start("devenv", $"\"{solution}\"");
        }
        else
        {
            console.Output.WriteLine("No solution file (.sln) found in the current directory.");
        }
        return ValueTask.CompletedTask;
    }
}
