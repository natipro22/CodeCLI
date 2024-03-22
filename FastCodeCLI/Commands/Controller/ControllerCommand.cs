using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Controller;
[Command("generate controller", "(generate|g) (controller|ct)$", Description = "Creates a new, generic controller definition in the given project.")]
public class ControllerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the controller")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetControllerService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
