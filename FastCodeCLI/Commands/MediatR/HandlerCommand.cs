using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.MediatR;
[Command("generate mediatr handler", "(generate|g) (mediatr|m) (handler|h)$", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetHandlerService(Name, Response, Path);

        string fileName = commandService.CreateFile();
        
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
