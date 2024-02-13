using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Enum;
[Command("generate enum", Description = "Generates a new, generic enum definition in the given project.")]
public class EnumCommand : BaseCommand
{

    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get; set; }

    [CommandOption('p', Description = "The name of the project in which to create the enum. Default is the configured startup project for the solution.")]
    public string Project { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
