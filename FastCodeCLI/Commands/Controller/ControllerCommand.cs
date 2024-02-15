using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Controller;
[Command("generate controller", "(generate|g) (controller|ct)$", Description = "Creates a new, generic controller definition in the given project.")]
public class ControllerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the controller")]
    public string Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
