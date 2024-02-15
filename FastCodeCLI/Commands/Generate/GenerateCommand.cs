using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Generate;
[Command("generate", "(generate|g)$", Description = "Generates and/or modifies files based on a schematic.")]
public class GenerateCommand : ICommand
{

    public ValueTask ExecuteAsync(IConsole console)
    {
        console.Output.WriteLine("generate working");
        return ValueTask.CompletedTask;
    }
}
