using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.Interface;
[Command("generate interface(i)", "(generate|g) (interface|i)$", Description = "Creates a new, generic interface definition in the given project.")]
public class InterfaceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the base interface.")]
    public IEnumerable<string> Extends { get; set; } = Enumerable.Empty<string>();

    [CommandOption('x', Description = "A prefix to apply to generated selectors.")]
    public char Prefix { get; set; } = 'I';


    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        // Get the service.
        ICommandService interfaceService = CommandServiceFactory.GetInterfaceService(Name, Extends, Prefix, Path);

        // Create file
        string fileName = interfaceService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
