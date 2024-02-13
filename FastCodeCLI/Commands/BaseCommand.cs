using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands;
[Command]
public abstract class BaseCommand : ICommand
{

    [CommandOption('p', Description = "The name of the project.")]
    public string Project { get; set; }

    public abstract ValueTask ExecuteAsync(IConsole console);
}
