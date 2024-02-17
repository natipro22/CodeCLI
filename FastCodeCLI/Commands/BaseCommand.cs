using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Code.Commands;
[Command]
public abstract class BaseCommand : ICommand
{

    protected string _fileName = string.Empty;

    [CommandOption('p', Description = "The name of the project.")]
    public string? Project { get; set; }

    public abstract ValueTask ExecuteAsync(IConsole console);
    
}

