using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Interface;
[Command("generate interface", "(generate|g) (interface|i)$", Description = "Creates a new, generic interface definition in the given project.")]
public class InterfaceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get; set; } = string.Empty;

    [CommandOption('x', Description = "A prefix to apply to generated selectors.")]
    public char Prefix { get; set; } = 'I';


    public override ValueTask ExecuteAsync(IConsole console)
    {
        // Get the service.
        ICommandService interfaceService = CommandServiceFactory.GetInterfaceService(Name, Prefix, Path);
        
        // Create file
        string fileName = interfaceService.CreateFile();
        
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
