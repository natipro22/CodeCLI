using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Interface;
[Command("g i", Description = "Creates a new, generic interface definition in the given project.")]
public class ICommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the enum.")]
    public string Name { get; set; }


    [CommandOption('x', Description = "A prefix to apply to generated selectors.")]
    public string Prefix { get; set; }


    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
