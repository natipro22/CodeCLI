using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace FastCodeCLI.Commands.Dot;
[Command("dot", "[.]", Description = "Launch Visual studio with the specified solution")]
public class DotCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string[] getFiles = Directory.GetFiles(currentDirectory, "*.sln");
        if (getFiles.Any())
        {
            string solution = getFiles.First();
            try
            {
                Process.Start("devenv", $"\"{solution}\"");
            }
            catch (Exception e)
            {
                console.Error.WriteLine(e.Message);
            }
        }
        else
        {
            console.Output.WriteLine("No solution file (.sln) found in the current directory.");
        }
        return ValueTask.CompletedTask;
    }
}
