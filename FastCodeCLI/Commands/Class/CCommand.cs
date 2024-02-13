using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Class;
[Command("g c", Description = "Creates a new, generic class definition in the given project.")]
public class CCommand : BaseCommand
{

    [CommandParameter(0, IsRequired = true, Description = "The name of the class.")]
    public string Name { get; set; }

    [CommandOption('p', Description = "The name of the project.")]
    public string Project { get; set; }

    [CommandOption('a', Description = "abstract class")]
    public bool Abstract { get; set; } = false;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
