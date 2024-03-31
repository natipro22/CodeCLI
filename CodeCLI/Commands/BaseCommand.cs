using CliFx;
using CliFx.Attributes;

namespace CodeCLI.Commands;
[Command]
public abstract class BaseCommand : CommandBase, ICommand
{

    protected string _fileName = string.Empty;

    [CommandOption("path", 'p', Description = "The path of the file.")]
    public string Path { get; set; } = string.Empty;
    
}