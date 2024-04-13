using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands;
[Command]
public abstract class BaseCommand : CommandBase
{

    protected string _fileName = string.Empty;

    [CommandOption("path", 'p', Description = "The path of the file.")]
    public string Path { get; set; } = string.Empty;

}